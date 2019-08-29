using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class Cliente
    {
        public Cliente()
        {
            Activo = true;
        }

        //[Required(ErrorMessage = "Ingrese una descripción")]
        //[MinLength(3, ErrorMessage = "Ingrese minimi 3 caracteres")]
        //[MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public int Cuenta { get; set; }
        

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }
}
