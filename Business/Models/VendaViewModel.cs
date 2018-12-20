using System.Collections.Generic;

namespace Business.Models
{
    public class VendaViewModel : BaseModel
    {
        public VendaViewModel()
        {
            this.Vendas = new List<VendaModel>();
        }
        public VendaViewModel(string excessao)
        {
            this.deErro = excessao;
        }
        public List<VendaModel> Vendas { get; set; }
    }
}
