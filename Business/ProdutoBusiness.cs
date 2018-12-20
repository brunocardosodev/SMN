using Business.Models;
using DataAccess;
using System;
using System.Linq;

namespace Business
{
    public class ProdutoBusiness
    {
        public ProdutoModel Get(int idProduto)
        {
            try
            {
                var produtos = new ProdutoDataAccess().GetList();
                var produto = produtos.SingleOrDefault(x => x.idProduto == idProduto);

                var result = new ProdutoModel(produto.idProduto, produto.vrProduto, produto.nmProduto);

                return result;
            }
            catch (Exception e)
            {
                return new ProdutoModel(e.Message);
            }
        }

        public ProdutoViewModel GetList()
        {
            try
            {
                var produtosEntities = new ProdutoDataAccess().GetList();
                var result = new ProdutoViewModel();

                foreach (var item in produtosEntities)
                {
                    var produto = new ProdutoModel(item.idProduto, item.vrProduto, item.nmProduto);
                    result.Produtos.Add(produto);
                }

                return result;
            }
            catch (Exception e)
            {
                return new ProdutoViewModel(e.Message);
            }
        }
    }
}
