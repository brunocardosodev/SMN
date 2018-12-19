using Business;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/venda")]
    public class VendaController : ApiController
    {
        [HttpGet]
        [Route("GetList")]
        [CacheOutput(ServerTimeSpan = 120)]
        public VendaViewModel GetList()
        {
            var vendas = new VendaBusiness().GetList();

            return vendas;
        }

        [HttpGet]
        [Route("GetRankingProdutosByPeriodo")]
        [CacheOutput(ServerTimeSpan = 120)]
        public VendaViewModel GetRankingProdutosByPeriodo(DateTime dtInicio, DateTime dtFim)
        {
            var vendas = new VendaBusiness().GetRankingProdutosByPeriodo(dtInicio, dtFim);

            return vendas;
        }
    }
}
