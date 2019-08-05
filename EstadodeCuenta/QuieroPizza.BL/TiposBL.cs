using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class TiposBL
    {
        ContextoT _contextoT;
        public List<Tipos> ListadeTipos { get; set; }

        public TiposBL()
        {
            _contextoT = new ContextoT();
            ListadeTipos = new List<Tipos>();
        }

        public List<Tipos> ObtenerTipos()
        {
            ListadeTipos = _contextoT.Tipos.ToList();
            return ListadeTipos;
        }

        public Tipos ObtenerTipos(int id)
        {
            var Tipos = _contextoT.Tipos.Find(id);

            return Tipos;
        }

        public void GuardarTipos(Tipos Tipos)
        {
            if (Tipos.Id == 0)
            {
                _contextoT.Tipos.Add(Tipos);
            }
            else
            {
                var TiposExistente = _contextoT.Tipos.Find(Tipos.Id);
                TiposExistente.Nombre = Tipos.Nombre;
                TiposExistente.Cuenta = Tipos.Cuenta;
            }

            _contextoT.SaveChanges();
        }

        public void EliminarTipos(int id)
        {
            var Tipos = _contextoT.Tipos.Find(id);

            _contextoT.Tipos.Remove(Tipos);
            _contextoT.SaveChanges();
        }

    }
}

