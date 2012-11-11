using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_beg_manufacturer.Models;

namespace mvc_beg_manufacturer.Controllers
{
    public class ManufacturerController : Controller
    {
        //
        // GET: /Manufacturer/

        public ActionResult Index()
        {
            ManufacturerDB db = new ManufacturerDB();

            IDictionary<int, string> fabricantes = db.GetManufacturersList();
            return View(fabricantes);
        }

        // GET: /Manufacturer/Details/id
        public ActionResult Details(int id)
        {
            ManufacturerDB db = new ManufacturerDB();
            Manufacturer manufacturer = db.GetManufacturerByID(id);

            return View(manufacturer);
        }
        // GET: /Manufacturer/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // GET: /Manufacturer/Guardar
        public ActionResult Guardar(Manufacturer m)
        {
            ViewData["Manufacturer"] = string.Format("Nombre: {0}, Country: {1}", 
                                            m.ManufacturerName, m.ManufacturerCountry);
            return View();
        }
    }
}
