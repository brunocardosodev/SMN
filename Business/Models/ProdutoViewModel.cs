using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
