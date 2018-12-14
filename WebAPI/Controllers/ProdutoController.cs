using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        private static List<Produto> produtos = new List<Produto>();
        private const string path = "D:SMN/produtos.txt";
        [HttpGet]
        public List<Produto> Get()
        {
            if (File.Exists(path))
            {
                Stream file = File.Open(path, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                while (reader.ReadLine() != null)
                {
                    var row = reader.ReadLine();

                    if (row != null)
                    {
                        var text = row.Split(';');
                        produtos.Add(new Produto(Convert.ToInt32(text[0]), text[1], text[2]));
                    }
                }

                reader.Close();
                file.Close();
            }

           return produtos;
        }
    }
}
