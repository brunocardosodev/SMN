using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class VendaBusiness
    {
        public List<VendaModel> GetList()
        {
            try
            {
                var vendas = new DataAccess.VendaDataAccess().GetList();

                var result = new List<VendaModel>();
                foreach (var item in vendas)
                {
                    var venda = new VendaModel(item.cnpj, item.dtVenda, item.idProduto, new ProdutoBusiness().Get(item.idProduto).nmProduto);
                    result.Add(venda);
                }

                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        //public List<VendaModel> GetRankingProdutosByPeriodo(DateTime dtInicial, DateTime dtFinal)
        //{
        //    var vendas = new DataAccess.VendaDataAccess().GetList();
        //    var result = vendas.AsEnumerable().Where(x => x.dtVenda >= dtInicial && x.dtVenda <= dtFinal).ToList();

        //    var rankingResult = from venda in result
        //                        group venda by venda.idProduto into vendasGroup
        //                        select new
        //                        {
        //                            idProduto = vendasGroup.Key,
        //                            count = vendasGroup.Count()
        //                        };

        //    return new List<VendaModel>();
        //}
    }
}
