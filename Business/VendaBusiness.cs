using Business.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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
                        var venda = new VendaModel(item.nuCNPJ, item.dtVenda, item.idProduto, produto.nmProduto, produto.vrProduto);
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

                        var itemRank = new RankingModel(produto.nmProduto, item.qtdeVendas, decimal.Parse(vrProduto) * item.qtdeVendas, null, null);
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

                filter = filter.OrderByDescending(x => x.dtVenda).ToList();

                var result = new VendaViewModel();

                foreach (var item in filter)
                {
                    var produto = new ProdutoBusiness().Get(item.idProduto);
                    if (produto != null)
                    {
                        var venda = new VendaModel(item.nuCNPJ, item.dtVenda, item.idProduto, produto.nmProduto, produto.vrProduto);
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

        public RankingViewModel GetRankingVendasByMes(int? ano)
        {
            try
            {
                var vendas = new DataAccess.VendaDataAccess().GetList();
                var filter = vendas.AsEnumerable().Where(x => (ano == null || x.dtVenda.Year == ano)).ToList();

                var ranking = from venda in filter
                              group venda by venda.dtVenda.Month into vendasGroup
                              select new
                              {
                                  mes = vendasGroup.Key,
                                  qtdeVendas = vendasGroup.Count(),
                                  vendas = vendasGroup
                              };

                ranking = ranking.OrderByDescending(x => x.qtdeVendas).ThenBy(x => x.mes);

                var rankingView = new RankingViewModel();
                decimal vrTotalVendas = 0;

                foreach (var item in ranking)
                {
                    var vendaGroup = item.vendas;
                    foreach (var itemVenda in vendaGroup)
                    {
                        var produto = new ProdutoBusiness().Get(itemVenda.idProduto);
                        if (produto != null)
                        {
                            var vrProduto = produto.vrProduto.Split('$')[1];
                            vrTotalVendas = vrTotalVendas + decimal.Parse(vrProduto);
                        }
                    }
                    var itemRank = new RankingModel(null, item.qtdeVendas, vrTotalVendas, DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(item.mes), null);
                    rankingView.Ranking.Add(itemRank);
                    vrTotalVendas = 0;
                }

                return rankingView;
            }
            catch (Exception e)
            {
                return new RankingViewModel(e.Message);
            }
        }

        public async Task<RankingViewModel> GetRankingClientes(int? ano)
        {
            try
            {
                //Lista de vendas
                var vendas = new DataAccess.VendaDataAccess().GetList();

                //Filtro
                var filter = vendas.AsEnumerable().Where(x => (ano == null || x.dtVenda.Year == ano)).ToList();

                //Ranking
                var ranking = from venda in filter
                              group venda by venda.nuCNPJ into vendasGroup
                              select new
                              {
                                  cnpj = vendasGroup.Key,
                                  qtdeVendas = vendasGroup.Count(),
                                  vendas = vendasGroup
                              };
                //Ordenação
                ranking = ranking.OrderByDescending(x => x.qtdeVendas);

                //Transformo o objeto anônimo em viewmodel
                var rankingView = new RankingViewModel();
                decimal vrTotalVendas = 0;
                var nmCliente = string.Empty;

                foreach (var item in ranking)
                {
                    var vendaModelList = new List<VendaModel>();

                    foreach (var itemVenda in item.vendas)
                    {
                        var produto = new ProdutoBusiness().Get(itemVenda.idProduto);
                        if (produto != null)
                        {
                            var vrProduto = produto.vrProduto.Split('$')[1];
                            vrTotalVendas = vrTotalVendas + decimal.Parse(vrProduto);
                            var vendaModel = new VendaModel(itemVenda.nuCNPJ, itemVenda.dtVenda, itemVenda.idProduto, produto.nmProduto, vrProduto);

                            vendaModelList.Add(vendaModel);
                        }
                    }

                    var cliente = await new ClienteBusiness().Get(item.cnpj);

                    nmCliente = cliente.icSucesso ? string.IsNullOrEmpty(cliente.nmCliente) ? cliente.nmFantasia : cliente.nmCliente : "Cliente não localizado";

                    var vendaViewModel = new VendaViewModel();
                    vendaViewModel.Vendas = vendaModelList;
                    var itemRank = new RankingModel(item.qtdeVendas, vrTotalVendas, nmCliente, vendaViewModel);
                    rankingView.Ranking.Add(itemRank);

                    vrTotalVendas = 0;
                }

                return rankingView;
            }
            catch (Exception e)
            {
                return new RankingViewModel(e.Message);
            }
        }
    }
}
