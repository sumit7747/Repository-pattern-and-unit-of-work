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
    public class GenericCaseStudiesController : Controller
    {
        private GenericUnitOfWork uow = null;
        //
        // GET: /CaseStudys/

        public GenericCaseStudiesController()
        {
            uow = new GenericUnitOfWork();
        }

        public GenericCaseStudiesController(GenericUnitOfWork uow_)
        {
            this.uow = uow_;
        }

        public ActionResult Index()
        {
            return View(uow.Repository<CaseStudy>().GetAll().ToList());
        }

        //
        // GET: /CaseStudys/Details/5

        public ActionResult Details(int id = 0)
        {
            CaseStudy CaseStudy = uow.Repository<CaseStudy>().Get(c => c.id == id);
            if (CaseStudy == null)
            {
                return HttpNotFound();
            }
            return View(CaseStudy);
        }

        //
        // GET: /CaseStudys/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CaseStudys/Create

        [HttpPost]
        public ActionResult Create(CaseStudy CaseStudy)
        {
            if (ModelState.IsValid)
            {
                uow.Repository<CaseStudy>().Add(CaseStudy);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(CaseStudy);
        }

        //
        // GET: /CaseStudys/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CaseStudy CaseStudy = uow.Repository<CaseStudy>().Get(c => c.id == id);
            if (CaseStudy == null)
            {
                return HttpNotFound();
            }
            return View(CaseStudy);
        }

        //
        // POST: /CaseStudys/Edit/5

        [HttpPost]
        public ActionResult Edit(CaseStudy CaseStudy)
        {
            if (ModelState.IsValid)
            {
                uow.Repository<CaseStudy>().Attach(CaseStudy);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CaseStudy);
        }

        //
        // GET: /CaseStudys/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CaseStudy CaseStudy = uow.Repository<CaseStudy>().Get(c => c.id == id);
            if (CaseStudy == null)
            {
                return HttpNotFound();
            }
            return View(CaseStudy);
        }

        //
        // POST: /CaseStudys/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseStudy CaseStudy = uow.Repository<CaseStudy>().Get(c => c.id == id);
            uow.Repository<CaseStudy>().Delete(CaseStudy);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
