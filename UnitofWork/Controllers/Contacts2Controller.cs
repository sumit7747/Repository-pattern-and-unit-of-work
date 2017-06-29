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
    public class Contacts2Controller : Controller
    {
        private ContactsRepository repo = new ContactsRepository();

        // GET: Contacts2
        public ActionResult Index()
        {
            return View(repo.GetAll().ToList());
        }

        // GET: Contacts2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            



            Contact contact = repo.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
    

        // GET: Contacts2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,ContactNumber,Address")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                repo.Add(contact);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = repo.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts2/Edit/
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,ContactNumber,Address")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                repo.Attach(contact);

                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = repo.Get(c => c.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {


            Contact contact = repo.Get(c=>c.ID==id);
            repo.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
