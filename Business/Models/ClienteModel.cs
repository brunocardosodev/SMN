using System.Threading.Tasks;

namespace Business.Models
{
    public class ClienteModel : BaseModel
    {
        public ClienteModel(string nmCliente, string nmFantasia)
        {
            this.nmCliente = nmCliente;
            this.nmFantasia = nmFantasia;
        }
        public ClienteModel(string excessao)
        {
            this.deErro = excessao;
        }

        public string nmCliente { get; set; }
        public string nmFantasia { get; set; }
    }
}
