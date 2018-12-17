using Business;
using Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        [HttpGet]
        public List<ProdutoModel> Get()
        {
            var produtos = new ProdutoBusiness().GetList();

            return produtos;
        }
    }
}
