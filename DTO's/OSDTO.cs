using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.DTO

{
    public class OSDTO

    {

        public int Id { get; set; }
        public decimal ValordaObra { get; set; }
        public ClienteDTO Cliente { get; set; }
        public FuncionarioDTO Funcionarios { get; set; }
        public ObraDTO Obras { get; set; }

    }
}
