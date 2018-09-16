using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {

            var models = (new Contact()).GetAll();

            return View(models);
        }


        public ActionResult Create()
        {
            return View(new Contact());
        }



        [HttpPost]
        public ActionResult Create(Contact model)
        {

            model.Insert();
            return RedirectToAction("index");
        }

        public ActionResult Edit(string id)
        {

            var models = (new Contact()).Get(id);

            return View(models);
        }

        [HttpPost]
        public ActionResult Edit(Contact model)
        {

            model.Update();

            return RedirectToAction("index");
        }


        public ActionResult Delete(string id)
        {


            new Contact().Delete(id);

            return RedirectToAction("index");
        }
    }
}