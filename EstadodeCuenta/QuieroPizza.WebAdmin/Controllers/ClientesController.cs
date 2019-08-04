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

        public ClientesController()
        {
            _ClientesBL = new ClientesBL();
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

            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Cliente Cliente)
        {
            _ClientesBL.GuardarCliente(Cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var Cliente = _ClientesBL.ObtenerCliente(id);

            return View(Cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente Cliente)
        {
            _ClientesBL.GuardarCliente(Cliente);

            return RedirectToAction("Index");
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
    }
}