using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Productos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Producto producto1 = new Producto();
            producto1.Id = 1;
            producto1.Descripcion = "Laptop";

            Producto producto2 = new Producto();
            producto2.Id = 2;
            producto2.Descripcion = "Mouse";

            Producto producto3 = new Producto();
            producto3.Id = 3;
            producto3.Descripcion = "Monitor";

            List<Producto> listaProductos = new List<Producto>();
            listaProductos.Add(producto1);
            listaProductos.Add(producto2);
            listaProductos.Add(producto3);


            return View(listaProductos);
        }
    }
}