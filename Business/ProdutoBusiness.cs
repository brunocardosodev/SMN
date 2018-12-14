using DataAccess;
using Business.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Business
{
    public class ProdutoBusiness
    {
        public Produto Get(int idProduto)
        {
            try
            {
                var produtos = new ProdutoDataAccess().GetList();
                var produto = produtos.SingleOrDefault(x => x.idProduto == idProduto);

                var result = new Produto(produto.idProduto, produto.vrProduto, produto.nmProduto);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public List<Produto> GetList()
        {
            try
            {
                var produtosEntities = new ProdutoDataAccess().GetList();
                var result = new List<Produto>();
                foreach (var item in produtosEntities)
                {
                    var produto = new Produto(item.idProduto, item.vrProduto, item.nmProduto);
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
