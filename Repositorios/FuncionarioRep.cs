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
    public class FuncionarioRepositorio
    {

        private readonly string _connection = @"Data Source=DESKTOP-H20UE5F\SQLEXPRESS;Initial Catalog=apidagalera;Integrated Security=True;";

        public FuncionarioDTO SalvarFuncionario(Funcionario funcionario)
        {
            

            int IdFuncionarioCriado = -1;
            try
            {
                var query = @"INSERT INTO Funcionario 
                              (Nome, CPF, Cargo) 
                              OUTPUT Inserted.Id
                              VALUES (@nome, @cpf, @cargo)";
                using (var connection = new SqlConnection(_connection))
                {


                    var parametros = new
                    {
                        funcionario.Nome,
                        funcionario.CPF,
                        funcionario.Cargo
                    };
                    return connection.QueryFirstOrDefault<FuncionarioDTO>(query, parametros);
                }
                
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
                    //Executa a consulta e retorna a primeira coluna da primeira linha no conjunto de resultados retornado pela consulta. Colunas ou linhas adicionais são ignoradas.
              

 
        }

      

        public FuncionarioDTO BuscarFuncionario(int IdFuncionario)
        {

            try
            {
                var query = @"SELECT * FROM Cliente WHERE Id = @IdCliente";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {
                        IdFuncionario
                    };
                    return connection.QueryFirstOrDefault<FuncionarioDTO>(query, parametros);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return null;

            }

        }

        public List<FuncionarioDTO> BuscarTodosFuncionarios()
        {

            try
            {
                var query = @"SELECT * FROM Funcionario";

                using (var connection = new SqlConnection(_connection))
                {

       

                    return connection.Query<FuncionarioDTO>(query).ToList();
                
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
                return new List<FuncionarioDTO>();

            }

            //public bool AtualizarFuncionario (Funcionario funcionario)
            //{




            //}
        }

        //public FuncionarioDTO AtualizarFuncionario(string nome)
        //{

        //    try
        //    {
        //        var query = @"UPDATE Funcionario
        //                    SET Nome = @nome,
        //                    WHERE Id = @id";

        //        using (var sql = new SqlConnection(connection))

        //        {

        //            SqlCommand command = new SqlCommand(query, sql);
        //            command.Parameters.AddWithValue("@nome", pessoa.Nome);
        //            command.Parameters.AddWithValue("@Datanascimento", pessoa.DatadeNascimento);
        //            command.Parameters.AddWithValue("@telefone", pessoa.Telefone);
        //            command.Connection.Open();
        //            command.ExecuteNonQuery();

        //        }
        //        Console.WriteLine("Pessoa atualizada com sucesso.");
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine("Erro: " + ex.Message);

        //    }




        //}
    }

}