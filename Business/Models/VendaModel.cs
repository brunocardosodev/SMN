using System;

namespace Business.Models
{
    public class VendaModel : BaseModel
    {
        public string cnpj { get; set; }
        public DateTime dtVenda { get; set; }
        public int idProduto { get; set; }
        public string nmProduto { get; set; }
        public string vrProduto { get; set; }
        public VendaModel()
        {
        }
        public VendaModel(string cnpj, DateTime dtVenda, int idProduto, string nmProduto, string vrProduto)
        {
            this.cnpj = cnpj;
            this.dtVenda = dtVenda;
            this.idProduto = idProduto;
            this.nmProduto = nmProduto;
            this.vrProduto = vrProduto;
        }
    }
}
