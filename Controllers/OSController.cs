using Microsoft.AspNetCore.Mvc;
using ProjetoEmpreiteira.Repositorios;
using ProjetoEmpreiteira.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OSController : ControllerBase
    {

        private readonly OSRep osrep = new OSRep();

        [HttpPost]

        public IActionResult SalvarOS(ViewModelOS viewModelOS)
        {

            var resultado = osrep.SalvarOS(viewModelOS.SalvarOS);

            if (resultado) return Ok("Endereco cliente cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar o enderecodo cliente . Endereco não cadastrada.");

        }

        [HttpGet]
        public IActionResult BuscaTodosOS()
        {
            var resultado = osrep.BuscarTodosOS();

            if (resultado == null)
                return NotFound();
            return Ok();

        }




        [HttpPut]

        public IActionResult AtualizarOSs(int id, ViewModelAtualizarOS viewmodelatualizaros)
        {
            var resultado = osrep.AtualizarOS(viewmodelatualizaros.Id, viewmodelatualizaros.AtualizarOS);

            if (resultado)
                return Ok();
            return Ok();


        }

        [HttpDelete]

        public IActionResult DeletarOS(int id)
        {


            var resultado = osrep.DeletarOS(id);
            if (resultado)
                return Ok();
            return Ok();
        }

    }

}
