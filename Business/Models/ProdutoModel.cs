using System.Collections.Generic;

namespace Business.Models
{
    public class ProdutoModel : BaseModel
    {
        public int idProduto { get; set; }
        public string vrProduto { get; set; }
        public string nmProduto { get; set; }

        public ProdutoModel(string deErro)
        {
            this.deErro = deErro;
        }
        public ProdutoModel(int idProduto, string vrProduto, string nmProduto)
        {
            this.idProduto = idProduto;
            this.vrProduto = vrProduto;
            this.nmProduto = nmProduto;
        }
    }
}
