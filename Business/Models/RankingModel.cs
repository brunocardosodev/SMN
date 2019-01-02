namespace Business.Models
{
    public class RankingModel : BaseModel
    {
        public string nmProduto { get; set; }
        public int qtdeVendas { get; set; }
        public decimal vrTotalVendas { get; set; }
        public string deMes { get; set; }
        public string nmCliente { get; set; }
        public VendaViewModel VendaViewModel { get; set; }
        public RankingModel()
        {
        }
        public RankingModel(string nmProduto, int qtdeVendas, decimal vrTotalVendas, string deMes, string nmCliente)
        {
            this.nmProduto = nmProduto;
            this.qtdeVendas = qtdeVendas;
            this.vrTotalVendas = vrTotalVendas;
            this.deMes = deMes;
            this.nmCliente = nmCliente;
        }
        public RankingModel(int qtdeVendas, decimal vrTotalVendas, string nmCliente, VendaViewModel vendaViewModel)
        {
            this.qtdeVendas = qtdeVendas;
            this.vrTotalVendas = vrTotalVendas;
            this.nmCliente = nmCliente;
            this.VendaViewModel = vendaViewModel;
        }
    }
}
