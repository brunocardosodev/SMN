using Business.Models;
using System;
using System.Linq;

namespace Business
{
    public class VendaBusiness
    {
        public VendaViewModel GetList()
        {
            try
            {
                var vendas = new DataAccess.VendaDataAccess().GetList();

                var result = new VendaViewModel();
                foreach (var item in vendas)
                {
                    var produto = new ProdutoBusiness().Get(item.idProduto);
                    if (produto != null)
                    {
                        var venda = new VendaModel(item.cnpj, item.dtVenda, item.idProduto, produto.nmProduto, produto.vrProduto);
                        result.Vendas.Add(venda);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return new VendaViewModel(e.Message);
            }
        }

        public RankingViewModel GetRankingProdutosByPeriodo(DateTime dtInicial, DateTime dtFinal)
        {
            try
            {
                var vendas = new DataAccess.VendaDataAccess().GetList();
                var filter = vendas.AsEnumerable().Where(x => x.dtVenda >= dtInicial && x.dtVenda <= dtFinal).ToList();
                var ranking = from venda in filter
                              group venda by venda.idProduto into vendasGroup
                              select new
                              {
                                  idProduto = vendasGroup.Key,
                                  qtdeVendas = vendasGroup.Count(),
                              };

                ranking = ranking.OrderByDescending(x => x.qtdeVendas);

                var rankingView = new RankingViewModel();

                foreach (var item in ranking)
                {
                    var produto = new ProdutoBusiness().Get(item.idProduto);
                    if (produto != null)
                    {
                        var vrProduto = produto.vrProduto.Split('$')[1];

                        var itemRank = new RankingModel(produto.nmProduto, item.qtdeVendas, decimal.Parse(vrProduto) * item.qtdeVendas);
                        rankingView.Ranking.Add(itemRank);
                    }
                }

                return rankingView;
            }
            catch (Exception e)
            {
                return new RankingViewModel(e.Message);
            }
        }

        public VendaViewModel GetListProdutosByPeriodo(DateTime dtInicial, DateTime dtFinal)
        {
            try
            {
                var vendas = new DataAccess.VendaDataAccess().GetList();
                var filter = vendas.AsEnumerable().Where(x => x.dtVenda >= dtInicial && x.dtVenda <= dtFinal).ToList();

                var result = new VendaViewModel();
                foreach (var item in filter)
                {
                    var produto = new ProdutoBusiness().Get(item.idProduto);
                    if (produto != null)
                    {
                        var venda = new VendaModel(item.cnpj, item.dtVenda, item.idProduto, produto.nmProduto, produto.vrProduto);
                        result.Vendas.Add(venda);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return new VendaViewModel(e.Message);
            }
        }

    }
}
