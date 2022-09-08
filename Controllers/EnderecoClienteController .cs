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
    public class EnderecoClienteController : Controller
    {
        private readonly EnderecoClienteRep enderecoclienteRep = new EnderecoClienteRep();

        [HttpPost]
        public IActionResult Salvar(ViewModelEnderecoCliente viewModelEnderecoCliente)
        {
            var resultado = enderecoclienteRep.SalvarEnderecoCliente(viewModelEnderecoCliente.SalvarEnderecoCliente);

            if (resultado) return Ok("Endereco cliente cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar o enderecodo cliente . Endereco não cadastrada.");
        }
        
        [HttpGet]

        public IActionResult BuscarTodos()
        {

            var resultado = enderecoclienteRep.BuscarTodosEnderecoCliente();
            
            if (resultado == null || !resultado.Any())
                return NotFound();

            return Ok(resultado);

        }

        [HttpGet]

        public IActionResult BuscarTodos(int id)
        {

            var resultado = enderecoclienteRep.BuscarEnderecoClienteId(id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult AtualizarCliente(int id, ViewModelAtualizarEnderecoCliente viewModelAtualizarEnderecoCliente)
        {

            var resultado = enderecoclienteRep.AtualizarEnderecoCliente(viewModelAtualizarEnderecoCliente.Id, viewModelAtualizarEnderecoCliente.AtualizarEnderecoCliente);

            if(resultado) return Ok("Endereco cliente cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar o enderecodo cliente . Endereco não cadastrada.");

        }

        [HttpDelete]
        public IActionResult DeletarEnderecoCliente(int id)
        {

            var resultado = enderecoclienteRep.DeletarEnderecoClienteDTO(id);

            if (resultado) return Ok("Endereco cliente deletado com sucesso.");

            return Ok("Houve um problema ao deletar o enderecodo cliente . Endereco não deletado.");


        }
    }
}