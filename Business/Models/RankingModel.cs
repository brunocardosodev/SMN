using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class RankingModel : BaseModel
    {
        public string nmProduto { get; set; }
        public int qtdeVendas { get; set; }
        public decimal vrTotalVendas { get; set; }

        public RankingModel(string nmProduto, int qtdeVendas, decimal vrTotalVendas)
        {
            this.nmProduto = nmProduto;
            this.qtdeVendas = qtdeVendas;
            this.vrTotalVendas = vrTotalVendas;
        }
    }
}
