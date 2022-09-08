using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEmpreiteira.Repositorios;
using ProjetoEmpreiteira.ViewModel;

namespace ProjetoEmpreiteira.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EnderecoObrasController : Controller
    {
        private readonly EnderecoObrasRep enderecoobrasRep = new EnderecoObrasRep();

        [HttpPost]
        public IActionResult Salvar(ViewModelSalvarEnderecoObras viewModelEnderecoObras)
        {
            var resultado = enderecoobrasRep.SalvarEnderecoObras(viewModelEnderecoObras.SalvarEnderecoObras);

            if (resultado) return Ok("Endereco obras cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar o enderecodo obras . Endereco não cadastrada.");
        }

        [HttpGet]

        public IActionResult BuscarTodos()
        {

            var resultado = enderecoobrasRep.BuscarTodosEnderecoObras();

            if (resultado == null || !resultado.Any())
                return NotFound();

            return Ok(resultado);

        }

        [HttpGet]

        public IActionResult BuscarTodos(int id)
        {

            var resultado = enderecoobrasRep.BuscarEnderecoObrasId(id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult AtualizarObras(int id, ViewModelAtualizarEnderecoObras viewModelAtualizarEnderecoObras)
        {

            var resultado = enderecoobrasRep.AtualizarEnderecoObras(viewModelAtualizarEnderecoObras.Id, viewModelAtualizarEnderecoObras.AtualizarEnderecoObras);

            if (resultado) return Ok("Endereco obras cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar o enderecodo obras . Endereco não cadastrada.");

        }

        [HttpDelete]
        public IActionResult DeletarEnderecoObras(int id)
        {

            var resultado = enderecoobrasRep.DeletarEnderecoObrasDTO(id);

            if (resultado) return Ok("Endereco obras deletado com sucesso.");

            return Ok("Houve um problema ao deletar o enderecodo obras . Endereco não deletado.");


        }
    }
}
