namespace Business.Models
{
    public class RankingModel : BaseModel
    {
        public string nmProduto { get; set; }
        public int qtdeVendas { get; set; }
        public decimal vrTotalVendas { get; set; }
        public string deMes { get; set; }

        public RankingModel(string nmProduto, int qtdeVendas, decimal vrTotalVendas, string deMes)
        {
            this.nmProduto = nmProduto;
            this.qtdeVendas = qtdeVendas;
            this.vrTotalVendas = vrTotalVendas;
            this.deMes = deMes;
        }
    }
}
