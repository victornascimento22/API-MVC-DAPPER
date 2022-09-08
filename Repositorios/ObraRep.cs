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
    public class ObraRep
    {

        private readonly string _connection = @"Data Source=ITELABD05\SQLEXPRESS;Initial Catalog=apidagalera;Integrated Security=True;";

        public bool SalvarObra(Obra obra)
        {

            try
            {

                var query = @"INSERT FROM Obra
                              (Descricao, DatadeInicio,PrevisaodeTermino)
                               VALUES (@descricao, @datadeinicio, @previsaodetermino)";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        obra.Descricao,
                        obra.DatadeInicio,
                        obra.PrevisaodeTermino
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

        public List<ObraDTO> BuscarTodosObras()
        {

            try
            {

                var query = @"SELECT * FROM Obras";

                using (var connection = new SqlConnection(_connection))
                {


                    return connection.Query<ObraDTO>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;

            }
        }

        public bool AtualizarObras(int id, Obra obra)
        {

            try
            {

                var query = @"UPDATE SET Descricao=@descricao, DatadeInicio=@datadeinicio, PrevisaodeTermino WHERE Id=@id";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        obra.Descricao,
                        obra.DatadeInicio,
                        obra.PrevisaodeTermino,
                        id
                    };

                    connection.Execute(query, parametros);
                    return true;

                }
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
         
        }

        public bool DeletarObra(int id)
        {

            try
            {

                var query = @"DELETE FROM Obra WHERE Id=@id";

                using(var connection = new SqlConnection(_connection))
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