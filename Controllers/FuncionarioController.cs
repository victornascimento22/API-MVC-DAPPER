using Microsoft.AspNetCore.Mvc;
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
    public class FuncionarioController : ControllerBase
    {

        private readonly FuncionarioRepositorio funcionariorep = new FuncionarioRepositorio();
     
        [HttpPost]

        public IActionResult SalvarFuncionario(ViewModelFuncionario viewModelFuncionario)
        {

            var resultado = funcionariorep.SalvarFuncionario(viewModelFuncionario.Funcionario);
            
            if(resultado)
            return Ok("Houve um problema ao salvar. Pessoa não cadastrada.");
            return Ok("Pessoa cadastrada com sucesso.");

        }
        
        [HttpGet]
        public IActionResult BuscarFuncionaroId(int id)
        {
            var resultado = funcionariorep.BuscarFuncionario(id);

            if (resultado == null)
                return NotFound();
            return Ok();

        }

        [HttpGet]
        public IActionResult BuscarTodosFuncionarios ()
        {

            var resultado = funcionariorep.BuscarTodosFuncionarios();

            if (resultado == null)
                return NotFound();
            return Ok();


        }
        

        [HttpPut]

        public IActionResult AtualizarFuncionario(AtualizarFuncionarioViewModel viewmodelatualizarfuncionario)
        {
            var resultado = funcionariorep.AtualizarFuncionario(viewmodelatualizarfuncionario.Id, viewmodelatualizarfuncionario.AtualizarFuncionario);

            if (resultado)
            return Ok();
            return Ok();


        }

        [HttpDelete]

        public IActionResult DeletarFuncionario(DeletarFuncionarioViewModel deletarFuncionarioViewModel, int id)
        {


             var resultado = funcionariorep.DeletarFuncionario(id)
        }

    }
}