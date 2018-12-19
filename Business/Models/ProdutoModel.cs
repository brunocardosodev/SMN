using System.Collections.Generic;

namespace Business.Models
{
    public class ProdutoViewModel : BaseModel
    {
        public ProdutoViewModel()
        {
            this.Produtos = new List<ProdutoModel>();
        }
        public ProdutoViewModel(string excecao)
        {
            this.deErro = excecao;
        }
        
        public List<ProdutoModel> Produtos { get; set; }
    }
    
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
