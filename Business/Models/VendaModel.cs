using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class VendaViewModel : BaseModel
    {
        public VendaViewModel()
        {
            this.Vendas = new List<VendaModel>();
        }
        public VendaViewModel(string excessao)
        {
            this.deErro = excessao;
        }
        public List<VendaModel> Vendas { get; set; }
    }
    public class VendaModel : BaseModel
    {
        public long cnpj { get; set; }
        public DateTime dtVenda { get; set; }
        public int idProduto { get; set; }
        public string nmProduto { get; set; }

        public VendaModel(long cnpj, DateTime dtVenda, int idProduto, string nmProduto)
        {
            this.cnpj = cnpj;
            this.dtVenda = dtVenda;
            this.idProduto = idProduto;
            this.nmProduto = nmProduto;
        }
    }
}
