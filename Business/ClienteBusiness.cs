using Business.Models;
using DataAccess;
using System;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteBusiness
    {
        public async Task<ClienteModel> Get(string cnpj)
        {
            try
            {
                var cliente = await new ClienteDataAccess().GetDadosPJ(cnpj);

                var clienteModel = new ClienteModel(cliente.nmCliente, cliente.nmFantasia);

                return clienteModel;
            }
            catch (Exception e)
            {
                return new ClienteModel(e.Message);
            }
        }
    }
}
