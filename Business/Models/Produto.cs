using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string vrProduto { get; set; }
        public string nmProduto { get; set; }

        public Produto(int idProduto, string vrProduto, string nmProduto)
        {
            this.idProduto = idProduto;
            this.vrProduto = vrProduto;
            this.nmProduto = nmProduto;
        }
    }
}
