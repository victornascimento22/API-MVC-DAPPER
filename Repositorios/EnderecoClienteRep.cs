using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ProjetoEmpreiteira.DTO;
using ProjetoEmpreiteira.Model;

namespace ProjetoEmpreiteira.Repositorios
{
    public class EnderecoClienteRep
    {

        private readonly string _connection = @"Data Source=ITELABD05\SQLEXPRESS;Initial Catalog=apidagalera;Integrated Security=True;";

        public bool SalvarEnderecoCliente(EnderecoCliente enderecocliente)
        {
            try
            {
                var query = @"INSERT INTO EnderecoCliente
                              (Rua, Numero, Estado, Cidade, IdCliente)                               
                              VALUES (@rua, @numero, @estado, @cidade, @idCliente)";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        enderecocliente.Rua,
                        enderecocliente.Numero,
                        enderecocliente.Estado,
                        enderecocliente.Cidade,
                        enderecocliente.IdCliente
                    };

                    connection.Execute(query, parametros);
                }

                Console.WriteLine("Endereço cadastrado com sucesso.");
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return false;

            }
        }

        public List<EnderecoClienteDTO> BuscarTodosEnderecoCliente()
        {


            try
            {

                var query = @"SELECT * FROM EnderecoCliente";

                using (var connection = new SqlConnection(_connection))
                {


                    return connection.Query<EnderecoClienteDTO>(query).ToList();


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;

            }

        }

        public EnderecoClienteDTO BuscarEnderecoClienteId(int id)
        {

            try
            {

                var query = @"SELECT * FROM EnderecoCliente WHERE Id=@id";


                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        id

                    };
                    return connection.QueryFirstOrDefault<EnderecoClienteDTO>(query, parametros);


                }
            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public bool AtualizarEnderecoCliente(int id, EnderecoCliente enderecocliente)
        {

            try
            {

                var query = @"UPDATE SET Rua=@rua, Numero=@numero, Estado=@estado, Cidade=@cidade Id=@id";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        enderecocliente.Rua,
                        enderecocliente.Numero,
                        enderecocliente.Estado,
                        enderecocliente.Cidade,
                        enderecocliente.Id

                    };
                    connection.Execute(query, parametros);
                    return true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public bool DeletarEnderecoClienteDTO(int id)
        {

            try
            {

                var query = @"DELETE FROM EnderecoCliente WHERE Id=@id";


                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {


                        id


                    };


                    connection.Execute(query, parametros);
                    return true;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }

        }
    }

    
}








