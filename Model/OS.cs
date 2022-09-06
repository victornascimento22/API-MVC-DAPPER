using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEmpreiteira.Model
{
    public class OS

    {

        public int Id { get; set; }
        public decimal ValordaObra { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionarios { get; set; }
        public int IdObras { get; set; }

    }
}
