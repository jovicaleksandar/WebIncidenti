using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebIncidenti.Models;

namespace WebIncidenti.Controllers
{
    public class IncidentiController : Controller
    {
        // GET: Incidenti
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Incident incident)
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;

            if (incident == null || incident.naziv == null || incident.opis == null || incident.boja == null)
            {
                return RedirectToAction("Invalid");
            }

            if (!incidenti.collection.Keys.Contains(incident.naziv))
            {
                incidenti.collection.Add(incident.naziv, incident);
                HttpContext.Application["incidenti"] = incidenti;
            }
            else
            {
                HttpContext.Application["incidenti"] = incidenti;
                return RedirectToAction("Error", incident);
            }

            return RedirectToAction("List");
        }

        public ActionResult Error(Incident incident)
        {
            ViewBag.incident = incident;

            return View();
        }

        public ActionResult Invalid()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            List<Incident> sort = new List<Incident>();

            foreach (Incident i in incidenti.collection.Values)
                sort.Add(i);

            sort = sort.OrderByDescending(x => x.prioritet).ToList();
            ViewBag.incidenti = sort;

            return View();
        }

        [HttpGet]
        public ActionResult Zuti()
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            ViewBag.incidenti = incidenti;

            return View();
        }

        [HttpGet]
        public ActionResult Crveni()
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            ViewBag.incidenti = incidenti;

            return View();
        }

        [HttpGet]
        public ActionResult Zeleni()
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            ViewBag.incidenti = incidenti;

            return View();
        }

        [HttpGet]
        public ActionResult Search(string key)
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            Incident i = new Incident();

            if (key == "")
                return RedirectToAction("List");
            else
            {
                if (incidenti.collection.Keys.Contains(key))
                {
                    i = incidenti.collection[key];
                    ViewBag.search = i;

                    return View();
                }
                else
                    return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult Delete(string key)
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            if (incidenti.collection.Keys.Contains(key))
                incidenti.collection.Remove(key);

            HttpContext.Application["incidenti"] = incidenti;

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Plus(string key)
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            if (incidenti.collection.Keys.Contains(key))
                incidenti.collection[key].prioritet += 1;

            HttpContext.Application["incidenti"] = incidenti;

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Minus(string key)
        {
            Incidenti incidenti = HttpContext.Application["incidenti"] as Incidenti;
            if (incidenti.collection.Keys.Contains(key))
                incidenti.collection[key].prioritet -= 1;

            HttpContext.Application["incidenti"] = incidenti;

            return RedirectToAction("List");
        }
    }
}