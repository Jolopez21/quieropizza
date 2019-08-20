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
            ListadeClientes = _contexto.Clientes
                .Include("Tipo")
                .ToList();

            return ListadeClientes;
        }

        public void GuardarCliente(Cliente Cliente)
        {
            if (Cliente.Id == 0)
            {
                _contexto.Clientes.Add(Cliente);
            }
            else
            {
                var ClienteExistente = _contexto.Clientes.Find(Cliente.Id);

                ClienteExistente.Nombre = Cliente.Nombre;
                ClienteExistente.TipoId = Cliente.TipoId;
                ClienteExistente.Cuenta = Cliente.Cuenta;
                ClienteExistente.UrlImagen = Cliente.UrlImagen;
            }

            _contexto.SaveChanges();
        }

        public Cliente ObtenerCliente(int id)
        {
            var Cliente = _contexto.Clientes
                .Include("Tipo").FirstOrDefault(p => p.Id == id);

            return Cliente;
        }

        public void EliminarCliente(int id)
        {
            var Cliente = _contexto.Clientes.Find(id);

            _contexto.Clientes.Remove(Cliente);
            _contexto.SaveChanges();
        }
    }
}
