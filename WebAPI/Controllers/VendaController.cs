using Business;
using Business.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/venda")]
    public class VendaController : ApiController
    {
        [HttpGet]
        public List<VendaModel> GetList()
        {
            var vendas = new VendaBusiness().GetList();

            return vendas;
        }
    }
}
