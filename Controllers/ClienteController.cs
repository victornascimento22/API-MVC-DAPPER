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
    public class ClienteController : ControllerBase 
    {
        private readonly ClienteRep clienteRep = new ClienteRep();

        [HttpPost]
        public IActionResult Salvar(ViewModelCliente viewModelCliente)

        {
            var resultado = clienteRep.SalvarCliente(viewModelCliente.ClienteSalvar);

            if (resultado) return Ok("Pessoa cadastrada com sucesso.");

            return Ok("Houve um problema ao salvar. Pessoa não cadastrada.");
        }

        [HttpGet]
        public IActionResult BuscarClienteId(int id) 
        {
            var resultado = clienteRep.BuscarCliente(id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult BuscarTodosClientes()
        {
            var resultado = clienteRep.BuscarTodosClientes();

            if (resultado == null || !resultado.Any())
                return NotFound();

            return Ok(resultado);
        }
        [HttpPut]
        public IActionResult AtualizarCliente(ViewModelAtualizarCliente viewmodelatualizarcliente)
        {
            var resultado = clienteRep.AtualizarCliente(viewmodelatualizarcliente.IdCliente, viewmodelatualizarcliente.AtualizarCliente);
            if (resultado) return Ok("Pessoa att com sucesso.");

           

            return Ok("Houve um problema ao att. Pessoa não att.");

        }

        [HttpDelete]
        public IActionResult DeletarCliente(ViewModelDeletarCliente viewModelDeletarCliente, int id)
        {

            var resultado = clienteRep.DeletarCliente(id);
            
            if (resultado) return Ok("Pessoa deletada");
                    return Ok("Erro ao deletar");
        }



    }
}