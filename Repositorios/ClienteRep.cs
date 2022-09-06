using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjetoEmpreiteira.Model;
using Dapper;
using ProjetoEmpreiteira.DTO;

namespace ProjetoEmpreiteira.Repositorios
{
    public class ClienteRep
    {
        private readonly string _connection = @"Data Source=ITELABD17\SQLEXPRESS;Initial Catalog=apidagalera;Integrated Security=True;";

        public bool SalvarCliente(Cliente cliente)
        {
            int IdPessoaCriada = -1;
            try
            {
                var query = @"INSERT INTO Cliente 
                              (Nome, CNPJ, Telefone) 
                              OUTPUT Inserted.Id
                              VALUES (@nome, @cnpj, @telefone)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@cnpj", cliente.CNPJ);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    command.Connection.Open();
                    IdPessoaCriada = (int)command.ExecuteScalar();

                    //Executa a consulta e retorna a primeira coluna da primeira linha no conjunto de resultados retornado pela consulta. Colunas ou linhas adicionais são ignoradas.
                }

                //SalvarEndereco(cliente.Endereco, IdPessoaCriada);

                Console.WriteLine("Pessoa cadastrada com sucesso.");
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return false;

            }
        }
        private void SalvarEnderecoCliente(EnderecoCliente endereco, int IdCliente)
        {
            try
            {
                var query = @"INSERT INTO Endereco 
                              (Rua, Numero, Estado, Cidade, IdCliente)                               
                              VALUES (@rua, @numero, @estado, @cidade, @idCliente)";

                using (var sql = new SqlConnection(_connection))
                {

                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@rua", endereco.Rua);
                    command.Parameters.AddWithValue("@numero", endereco.Numero);
                    command.Parameters.AddWithValue("@estado", endereco.Estado);
                    command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                    command.Parameters.AddWithValue("@idCliente", IdCliente);
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }

                Console.WriteLine("Endereço cadastrado com sucesso.");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);

            }
        }

        public ClienteDTO BuscarCliente(int IdCliente)
        {
            try
            {
                var query = @"SELECT * FROM Cliente WHERE Id = @IdCliente";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        IdCliente
                    };
                    return connection.QueryFirstOrDefault<ClienteDTO>(query, parametros);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return null;

            }
        }
        public List<ClienteDTO> BuscarTodosClientes()
        {
            try
            {
                var query = @"SELECT * FROM Cliente";

                using (var connection = new SqlConnection(_connection))
                {
                    return connection.Query<ClienteDTO>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return new List<ClienteDTO>();
            }
        }

        public bool AtualizarCliente(int id, Cliente cliente)
        {

            try
            {

                var query = @"UPDATE SET Nome=@nome, CNPJ=@cnpj, Telefone = @telefone WHERE Id=@id";

                using (var connection = new SqlConnection(_connection))
                {


                    var parametros = new
                    {

                        id

                    };

                    connection.Execute(query, parametros);
                }
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }


        }

        public bool DeletarCliente(int idcliente)
        {
            try
            {
                var query = @"DELETE FROM Cliente WHERE Id=@idcliente";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        idcliente

                    };

                    connection.Execute(query, parametros);

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }


    }
}

