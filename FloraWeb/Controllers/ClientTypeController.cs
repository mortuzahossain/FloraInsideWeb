using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloraWeb.Controllers
{
    public class ClientTypeController : Controller
    {
        // GET: ClientType
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientType/Create
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

        // GET: ClientType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientType/Edit/5
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

        // GET: ClientType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientType/Delete/5
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
