using Business;
using Business.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/venda")]
    public class VendaController : ApiController
    {
        /// <summary>
        /// 1. Ranking de produtos mais vendidos por período.
        /// </summary>
        [HttpGet]
        [Route("GetRankingProdutosByPeriodo")]
        [CacheOutput(ServerTimeSpan = 120)]
        public RankingViewModel GetRankingProdutosByPeriodo(DateTime dtInicio, DateTime dtFim)
        {
            var rankingProdutosByPeriodo = new VendaBusiness().GetRankingProdutosByPeriodo(dtInicio, dtFim);

            return rankingProdutosByPeriodo;
        }

        /// <summary>
        /// 2. Lista de produtos vendidos por período.
        /// </summary>
        [HttpGet]
        [Route("GetListProdutosByPeriodo")]
        [CacheOutput(ServerTimeSpan = 120)]
        public VendaViewModel GetListProdutosByPeriodo(DateTime dtInicio, DateTime dtFim)
        {
            var produtosByPeriodo = new VendaBusiness().GetListProdutosByPeriodo(dtInicio, dtFim);

            return produtosByPeriodo;
        }

        /// <summary>
        /// 3. Ranking de vendas por mês.
        /// </summary>
        [HttpGet]
        [Route("GetRankingVendasByMes")]
        [CacheOutput(ServerTimeSpan = 120)]
        public RankingViewModel GetRankingVendasByMes(int? ano)
        {
            var vendaMes = new VendaBusiness().GetRankingVendasByMes(ano);

            return vendaMes;
        }

        /// <summary>
        /// 5. Ranking de clientes.
        /// </summary>
        [HttpGet]
        [Route("GetRankingClientes")]
        [CacheOutput(ServerTimeSpan = 120)]
        public async Task<RankingViewModel> GetRankingClientes(int? ano)
        {
            var rankingClientes = await new VendaBusiness().GetRankingClientes(ano);

            return rankingClientes;
        }

        /// <summary>
        /// Retorna toda a lista de vendas
        /// </summary>
        [HttpGet]
        [Route("GetList")]
        [CacheOutput(ServerTimeSpan = 120)]
        public VendaViewModel GetList()
        {
            var vendas = new VendaBusiness().GetList();

            return vendas;
        }

        /// <summary>
        /// Testando serviço da receita
        /// </summary>
        [HttpGet]
        [Route("GetCliente")]
        [CacheOutput(ServerTimeSpan = 120)]
        public async Task<ClienteModel> Get(string cnpj)
        {
            var cliente = await new ClienteBusiness().Get(cnpj);
            
            return cliente;
        }
    }
}
