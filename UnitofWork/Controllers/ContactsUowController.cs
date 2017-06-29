using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnitofWork;

namespace UnitofWork.Controllers
{
    public class ContactsUowController : Controller
    {

        private UnitOfWork uow = null;


        public ContactsUowController()
        {

            uow = new UnitOfWork();


        }

        public ContactsUowController(UnitOfWork uow_)
        {
            this.uow = uow_;
        }

        public ActionResult Index()
        {
            return View(uow.ContactRepository.GetAll().ToList());
        }

        //
        // GET: /Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = uow.ContactRepository.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contacts/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contacts/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                uow.ContactRepository.Add(contact);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //
        // GET: /Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = uow.ContactRepository.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                uow.ContactRepository.Attach(contact);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = uow.ContactRepository.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = uow.ContactRepository.Get(c => c.ID == id);
            uow.ContactRepository.Delete(contact);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
