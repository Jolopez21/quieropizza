using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadodeCuenta.WebAdmin.Controllers
{
    public class TiposController : Controller
    {
        TiposBL _TiposBL;

        public TiposController()
        {
            _TiposBL = new TiposBL();
        }

        

        // GET: Tipos
        public ActionResult Index()
        {
        var listadeTipos = _TiposBL.ObtenerTipos();

          return View(listadeTipos);
        }

        public ActionResult Crear()
        {
            var nuevoTipos = new Tipos();

            return View(nuevoTipos);
        }

        [HttpPost]
        public ActionResult Crear(Tipos Tipos)
        {
            _TiposBL.GuardarTipos(Tipos);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var Tipos = _TiposBL.ObtenerTipos(id);

            return View(Tipos);
        }

        [HttpPost]
        public ActionResult Editar(Tipos Tipos)
        {
            _TiposBL.GuardarTipos(Tipos);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var Tipos = _TiposBL.ObtenerTipos(id);

            return View(Tipos);
        }

        public ActionResult Eliminar(int id)
        {
            var Tipos = _TiposBL.ObtenerTipos(id);

            return View(Tipos);
        }

        [HttpPost]
        public ActionResult Eliminar(Tipos Tipos)
        {
            _TiposBL.EliminarTipos(Tipos.Id);

            return RedirectToAction("Index");
        }
    }
}