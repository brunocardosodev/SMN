using DataAccess;
using Business.Models;
using System;
using System.Linq;
using System.Collections.Generic;

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
                throw new Exception();
            }
        }

        public List<ProdutoModel> GetList()
        {
            try
            {
                var produtosEntities = new ProdutoDataAccess().GetList();
                var result = new List<ProdutoModel>();
                foreach (var item in produtosEntities)
                {
                    var produto = new ProdutoModel(item.idProduto, item.vrProduto, item.nmProduto);
                    result.Add(produto);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
