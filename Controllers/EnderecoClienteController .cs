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
        
    }
}