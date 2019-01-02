using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DataAccess
{
    public class VendaDataAccess
    {
        private static List<Venda> vendas = new List<Venda>();
        public List<Venda> GetList()
        {
            var path = System.Configuration.ConfigurationSettings.AppSettings["PathVendas"];

            if (vendas.Count == 0)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        Stream file = File.Open(path, FileMode.Open);
                        StreamReader reader = new StreamReader(file);
                        var row = reader.ReadLine();
                        row = reader.ReadLine();

                        while (row != null)
                        {
                            if (row != null)
                            {
                                var text = row.Split(';');
                                var cnpj = text[0];
                                var idProduto = Convert.ToInt32(text[2]);
                                var dtVenda = DateTime.ParseExact(text[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                                vendas.Add(new Venda(cnpj, dtVenda, idProduto));
                            }

                            row = reader.ReadLine();
                        }

                        reader.Close();
                        file.Close();

                        return vendas;
                    }
                    catch (Exception e)
                    {
                        throw new Exception();
                    }
                }
            }

            return vendas;
        }
    }
}
