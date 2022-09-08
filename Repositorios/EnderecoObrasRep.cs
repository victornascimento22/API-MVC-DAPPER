using Dapper;
using ProjetoEmpreiteira.DTO;
using ProjetoEmpreiteira.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Repositorios
{
    public class EnderecoObrasRep
    {

        private readonly string _connection = @"Data Source=ITELABD05\SQLEXPRESS;Initial Catalog=apidagalera;Integrated Security=True;";

        public bool SalvarEnderecoObras(EnderecoObras enderecoobras)
        {
            try
            {
                var query = @"INSERT INTO EnderecoObras
                              (Rua, Numero, Estado, Cidade, IdObras)                               
                              VALUES (@rua, @numero, @estado, @cidade, @idObras)";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        enderecoobras.Rua,
                        enderecoobras.Numero,
                        enderecoobras.Estado,
                        enderecoobras.Cidade,
                        enderecoobras.IdObras
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

        public List<EnderecoObrasDTO> BuscarTodosEnderecoObras()
        {


            try
            {

                var query = @"SELECT * FROM EnderecoObras";

                using (var connection = new SqlConnection(_connection))
                {


                    return connection.Query<EnderecoObrasDTO>(query).ToList();


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;

            }

        }

        public EnderecoObrasDTO BuscarEnderecoObrasId(int id)
        {

            try
            {

                var query = @"SELECT * FROM EnderecoObras WHERE Id=@id";


                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        id

                    };
                    return connection.QueryFirstOrDefault<EnderecoObrasDTO>(query, parametros);


                }
            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public bool AtualizarEnderecoObras(int id, EnderecoObras enderecoobras)
        {

            try
            {

                var query = @"UPDATE SET Rua=@rua, Numero=@numero, Estado=@estado, Cidade=@cidade Id=@id";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        enderecoobras.Rua,
                        enderecoobras.Numero,
                        enderecoobras.Estado,
                        enderecoobras.Cidade,
                        enderecoobras.Id

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

        public bool DeletarEnderecoObrasDTO(int id)
        {

            try
            {

                var query = @"DELETE FROM EnderecoObras WHERE Id=@id";


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
