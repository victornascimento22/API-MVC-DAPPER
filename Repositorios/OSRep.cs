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
    public class OSRep { 


    private readonly string _connection = @"Data Source=ITELABD05\SQLEXPRESS;Initial Catalog=apidagalera;Integrated Security=True;";
    
    public bool SalvarOS(OS os)
    {

        try
        {

            var query = @"INSERT FROM OS
                              (ValordaObra, IdCliente,IdFuncionarios, IdObras)
                               VALUES (@valordaobra, @idcliente, @idfuncionarios, @idobras)";

            using (var connection = new SqlConnection(_connection))
            {

                var parametros = new
                {

                    os.ValordaObra,
                    os.IdCliente,
                    os.IdFuncionarios, 
                    os.IdObras
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

    public List<OSDTO> BuscarTodosOS()
    {

        try
        {

            var query = @"SELECT * FROM OS";

            using (var connection = new SqlConnection(_connection))
            {


                return connection.Query<OSDTO>(query).ToList();
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return null;

        }
    }

    public bool AtualizarOS(int id, OS os)
    {

        try
        {

            var query = @"UPDATE SET ValordaObra=@ValordaObra, IdCliente=@idcliente, IdFuncionarios, IdObras WHERE Id=@id";

            using (var connection = new SqlConnection(_connection))
            {

                var parametros = new
                {

                    os.ValordaObra,
                    os.IdCliente,
                    os.IdFuncionarios, 
                    os.IdObras,
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

    public bool DeletarOS(int id)
    {

        try
        {

            var query = @"DELETE FROM OS WHERE Id=@id";

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
