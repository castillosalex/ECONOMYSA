using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class ClienteBS
    {
        ClienteDA clienteDA = new ClienteDA();

        public List<ClienteE> ListadoCliente()
        {
            return clienteDA.ListadoCliente();
        }
        public int RegistrarCliente(ClienteE clienteE)
        {
            return clienteDA.RegistrarCliente(clienteE);
        }
        public int ActualizarCliente(ClienteE clienteE)
        {
            return clienteDA.ActualizarCliente(clienteE);
        }
        public int EliminarCliente(int ID)
        {
            return clienteDA.EliminarCliente(ID);
        }
    }
}
