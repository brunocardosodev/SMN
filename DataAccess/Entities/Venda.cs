using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Venda
    {
        public long cnpj { get; set; }
        public DateTime dtVenda { get; set; }
        public int idProduto { get; set; }

        public Venda(long cnpj, DateTime dtVenda, int idProduto)
        {
            this.cnpj = cnpj;
            this.dtVenda = dtVenda;
            this.idProduto = idProduto;
        }
    }
}
