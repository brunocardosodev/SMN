using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAccess
{
    public class ProdutoDataAccess
    {
        private static List<Produto> produtos = new List<Produto>();
        public List<Produto> GetList()
        {
            var path = System.Configuration.ConfigurationSettings.AppSettings["PathProduto"];

            if (produtos.Count == 0)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        Stream file = File.Open(path, FileMode.Open);
                        StreamReader reader = new StreamReader(file);
                        var row = reader.ReadLine();

                        while (row != null)
                        {
                            if (row != null)
                            {
                                var text = row.Split(';');
                                produtos.Add(new Produto(Convert.ToInt32(text[0]), text[1], text[2]));
                            }

                            row = reader.ReadLine();
                        }

                        reader.Close();
                        file.Close();

                        return produtos;
                    }
                    catch (Exception e)
                    {
                        throw new Exception();
                    }
                }
            }
            
            return produtos;
        }
    }
}

