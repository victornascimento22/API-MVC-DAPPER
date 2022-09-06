using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreiteira.DTO;
using ProjetoEmpreiteira.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ObraController : ControllerBase
    {
        private readonly string _connection = @"Data Source=ITELABD17\SQLEXPRESS;Initial Catalog=apidagalera;Integrated Security=True;";

        public bool SalvarObra(Obra obra)
        {

            try
            {

                var query = @"INSERT INTO Obra
                                    (Descricao, DatadeInicio, PrevisaodeTermino)";


                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        obra.Descricao,
                        obra.DatadeInicio,
                        obra.PrevisaodeTermino
                    };

                    connection.Execute(query, parametros);

                }
                return true;



            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro:", ex.Message);
                return false;
            }

        }

        public ObraDTO BuscarObra(int idobra)
        {

            try
            {

                var query = "SELECT * FROM WHERE Id=@idobra";

                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        idobra
                    };
                    return connection.QueryFirstOrDefault<ObraDTO>(query, parametros);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public bool AtualizarObra(int idcliente, Obra obra)
        {


            try
            {

                var query = @"UPDATE Obra SET Descricao = @descricao, DatadeInicio = @datadeinicio, PrevisaodeTermino = @previsaodetermino";


                using (var connection = new SqlConnection(_connection))
                {

                    var parametros = new
                    {

                        obra.Descricao,
                        obra.DatadeInicio,
                        obra.PrevisaodeTermino

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

        public bool DeletarObra(int id, Obra obra)
        {

            try
            {

                var query = @"DELETE FROM Obra WHERE Id = @id";

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

                Console.WriteLine("erro:",ex.Message);
                return false;

            }

}


}

    
}
