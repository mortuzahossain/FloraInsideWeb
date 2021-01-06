using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloraWeb.Controllers
{
    public class ClientDuetyController : Controller
    {
        // GET: ClientDuety
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientDuety/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientDuety/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientDuety/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientDuety/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientDuety/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientDuety/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientDuety/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
