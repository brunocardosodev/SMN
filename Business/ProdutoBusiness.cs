using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using DataAccess;


namespace Business
{
    public class ProdutoBusiness
    {
        public Produto Get(int idProduto)
        {
            var produtos = new ProdutoDataAccess().GetList();

            var result = produtos.AsEnumerable().SingleOrDefault(x => x.idProduto == idProduto);

            return result;
        }
    }
}
