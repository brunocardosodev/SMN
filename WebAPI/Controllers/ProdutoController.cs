﻿using Business;
using Business.Models;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 120)]
        [Route("Get")]
        public ProdutoViewModel Get()
        {
            var produtos = new ProdutoBusiness().GetList();

            return produtos;
        }
    }
}
