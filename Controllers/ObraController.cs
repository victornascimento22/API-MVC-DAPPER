using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreiteira.DTO;
using ProjetoEmpreiteira.Model;
using ProjetoEmpreiteira.Repositorios;
using ProjetoEmpreiteira.ViewModel;
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

            private readonly ObraRep obrasrep = new ObraRep();

            [HttpPost]

            public IActionResult SalvarObras(ViewModelSalvarObra viewModelObra)
            {

                var resultado = obrasrep.SalvarObra(viewModelObra.SalvarObra);

                if (resultado) return Ok("Endereco cliente cadastrado com sucesso.");

                return Ok("Houve um problema ao salvar o enderecodo cliente . Endereco não cadastrada.");

            }

            [HttpGet]
            public IActionResult BuscaTodosObras()
            {
            var resultado = obrasrep.BuscarTodosObras();

                if (resultado == null)
                    return NotFound();
                return Ok();

            }

           


            [HttpPut]

            public IActionResult AtualizarObras(ViewModelAtualizarObra viewmodelatualizarobras)
            {
                var resultado = obrasrep.AtualizarObras(viewmodelatualizarobras.Id, viewmodelatualizarobras.AtualizarObra);

                if (resultado)
                    return Ok();
                return Ok();


            }

            [HttpDelete]

            public IActionResult DeletarObras(int id)
            {


                var resultado = obrasrep.DeletarObra(id);
                if (resultado)
                    return Ok();
                return Ok();
            }

        }
    }
