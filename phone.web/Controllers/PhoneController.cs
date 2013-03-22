using phone.core.Models;
using phone.core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phone.web.Controllers
{
    public class PhoneController : Controller
    {
        //
        // GET: /Phone/

        public ActionResult Index()
        {
            IService service = new PhoneService();
            ICollection<PhoneModel> phones = service.listPhones();
            return View(phones);
        }

        //
        // GET: /Phone/Details/5

        public ActionResult Details(int id)
        {
            IService service = new PhoneService();
            return View(service.getPhoneById(id));
        }

        //
        // GET: /Phone/Create

        public ActionResult Create()
        {
            IService service = new PhoneService();
            PhoneModel phone = new PhoneModel();

            //Figure out how to create the dropdown list for the page
            //http://blinkingcaret.wordpress.com/2012/08/11/using-html-dropdownlistfor/

            ViewBag.phoneCd = new SelectList(service.getPhoneCds(), "phoneCd", "phoneCodeDescription", phone.phoneCd); 
            return View(phone);
        }

        //
        // POST: /Phone/Create

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

        //
        // GET: /Phone/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Phone/Edit/5

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

        //
        // GET: /Phone/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Phone/Delete/5

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
