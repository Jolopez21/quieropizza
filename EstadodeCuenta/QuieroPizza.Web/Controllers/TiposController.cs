using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadodeCuenta.Web.Controllers
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

        
    }
}
