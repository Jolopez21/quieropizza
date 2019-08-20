using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadodeCuenta.WebAdmin.Controllers
{
    public class ClientesController : Controller
    {
        ClientesBL _ClientesBL;
        TiposBL _TiposBL;

        public ClientesController()
        {
            _ClientesBL = new ClientesBL();
            _TiposBL = new TiposBL();
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _ClientesBL.ObtenerClientes();

            return View(listadeClientes);
        }

        public ActionResult Crear()
        {
            var nuevoCliente = new Cliente();
            var Tipos = _TiposBL.ObtenerTipos();


            ViewBag.TipoId =
                new SelectList(Tipos, "Id", "Descripcion");

            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Cliente Cliente, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (Cliente.TipoId == 0)
                {
                    ModelState.AddModelError("TipoId", "Ingreses los tipos");
                    return View(Cliente);
                }

                if (imagen != null)
                {
                    Cliente.UrlImagen = GuardarImagen(imagen);
                }
                _ClientesBL.GuardarCliente(Cliente);

            return RedirectToAction("Index");
        }
            var Tipos = _TiposBL.ObtenerTipos();


            ViewBag.TipoId =
                new SelectList(Tipos, "Id", "Descripcion");
            return View(Cliente);
        }

        public ActionResult Editar(int id)
        {
            var Cliente = _ClientesBL.ObtenerCliente(id);
            var Tipos = _TiposBL.ObtenerTipos();

            ViewBag.TipoId =
                new SelectList(Tipos, "Id", "Descripcion", Cliente.TipoId);

            return View(Cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente Cliente)
        {
            {
                if (ModelState.IsValid)
                {
                    if (Cliente.TipoId == 0)
                    {
                        ModelState.AddModelError("TipoId", "Ingreses los tipos");
                        return View(Cliente);
                    }
                    _ClientesBL.GuardarCliente(Cliente);

                    return RedirectToAction("Index");
                }
                var Tipos = _TiposBL.ObtenerTipos();


                ViewBag.TipoId =
                    new SelectList(Tipos, "Id", "Descripcion");
                return View(Cliente);
            }
        }

        public ActionResult Detalle(int id)
        {
            var Cliente = _ClientesBL.ObtenerCliente(id);

            return View(Cliente);
        }

        public ActionResult Eliminar(int id)
        {
            var Cliente = _ClientesBL.ObtenerCliente(id);

            return View(Cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente Cliente)
        {
            _ClientesBL.EliminarCliente(Cliente.Id);

            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}