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
    public class GenericContactsController : Controller
    {
        private GenericUnitOfWork uow = null;
        //
        // GET: /Contacts/

        public GenericContactsController()
        {
            uow = new GenericUnitOfWork();
        }

        public GenericContactsController(GenericUnitOfWork uow_)
        {
            this.uow = uow_;
        }

        public ActionResult Index()
        {
            return View(uow.Repository<Contact>().GetAll().ToList());
        }

        //
        // GET: /Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = uow.Repository<Contact>().Get(c => c.ID == id);
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
                uow.Repository<Contact>().Add(contact);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //
        // GET: /Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = uow.Repository<Contact>().Get(c => c.ID == id);
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
                uow.Repository<Contact>().Attach(contact);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = uow.Repository<Contact>().Get(c => c.ID == id);
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
            Contact contact = uow.Repository<Contact>().Get(c => c.ID == id);
            uow.Repository<Contact>().Delete(contact);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
