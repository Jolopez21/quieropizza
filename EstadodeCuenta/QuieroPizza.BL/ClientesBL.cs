using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class ClientesBL
    {
        Contexto _contexto;
        public List<Cliente> ListadeClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeClientes = new List<Cliente>();
        }

        public List<Cliente> ObtenerClientes()
        {
            ListadeClientes = _contexto.Clientes.ToList();
            return ListadeClientes;
        }

        public Cliente ObtenerCliente(int id)
        {
            var Cliente = _contexto.Clientes.Find(id);

            return Cliente;
        }

        public void GuardarCliente(Cliente Cliente)
        {
            if (Cliente.Id == 0)
            {
                _contexto.Clientes.Add(Cliente);
            } else
            {
                var ClienteExistente = _contexto.Clientes.Find(Cliente.Id);
                ClienteExistente.Nombre = Cliente.Nombre;
                ClienteExistente.Cuenta = Cliente.Cuenta;
            }

            _contexto.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            var Cliente = _contexto.Clientes.Find(id);

            _contexto.Clientes.Remove(Cliente);
            _contexto.SaveChanges();
        }
        
    }
}
