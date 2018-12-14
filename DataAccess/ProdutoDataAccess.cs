using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace DataAccess
{
    public class ProdutoDataAccess
    {
        private static List<Produto> produtos = new List<Produto>();
        public List<Produto> GetList()
        {
            var path = "D:SMN/produtos.txt";

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

