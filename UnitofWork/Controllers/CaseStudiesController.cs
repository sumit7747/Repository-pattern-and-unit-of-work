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
    public class CaseStudiesController : Controller
    {
        private asoEntities db = new asoEntities();

        // GET: GenericCaseStudies
        public ActionResult Index()
        {
            return View(db.CaseStudies.ToList());
        }

        // GET: GenericCaseStudies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStudy caseStudy = db.CaseStudies.Find(id);
            if (caseStudy == null)
            {
                return HttpNotFound();
            }
            return View(caseStudy);
        }

        // GET: GenericCaseStudies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenericCaseStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,PageName,title_seo,desc_seo,key_seo,banner_img,Title,Mail_Content,footer,created_date,Category")] CaseStudy caseStudy)
        {
            if (ModelState.IsValid)
            {
                db.CaseStudies.Add(caseStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseStudy);
        }

        // GET: GenericCaseStudies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStudy caseStudy = db.CaseStudies.Find(id);
            if (caseStudy == null)
            {
                return HttpNotFound();
            }
            return View(caseStudy);
        }

        // POST: GenericCaseStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,PageName,title_seo,desc_seo,key_seo,banner_img,Title,Mail_Content,footer,created_date,Category")] CaseStudy caseStudy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseStudy);
        }

        // GET: GenericCaseStudies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStudy caseStudy = db.CaseStudies.Find(id);
            if (caseStudy == null)
            {
                return HttpNotFound();
            }
            return View(caseStudy);
        }

        // POST: GenericCaseStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseStudy caseStudy = db.CaseStudies.Find(id);
            db.CaseStudies.Remove(caseStudy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
