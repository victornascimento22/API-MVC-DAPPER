using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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






    }

}

