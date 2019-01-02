using System;

namespace DataAccess.Entities
{
    public class Venda
    {
        public string nuCNPJ { get; set; }
        public DateTime dtVenda { get; set; }
        public int idProduto { get; set; }

        public Venda(string nuCNPJ, DateTime dtVenda, int idProduto)
        {
            this.nuCNPJ = nuCNPJ;
            this.dtVenda = dtVenda;
            this.idProduto = idProduto;
        }
    }
}
