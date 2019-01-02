using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Cliente
    {
        public string nuCNPJ { get; set; }
        public string nmCliente { get; set; }
        public string nmFantasia { get; set; }

        public Cliente(string nuCNPJ, string nmCliente, string nmFantasia)
        {
            this.nuCNPJ = nuCNPJ;
            this.nmCliente = nmCliente;
            this.nmFantasia = nmFantasia;
        }
    }
}
