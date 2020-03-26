using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseManagement.DataAccess;
using CaseManagement.Models;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class CaseReviewController : Controller
    {
        private CaseContext db = new CaseContext();

        // GET: CaseReviews
        public ActionResult Index()
        {
            return View(db.CaseReviews.ToList());
        }

        // GET: CaseReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseReview caseReview = db.CaseReviews.Find(id);
            if (caseReview == null)
            {
                return HttpNotFound();
            }
            return View(caseReview);
        }

        // GET: CaseReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CaseId,ReviewDetails,CreatedBy,CreatedOn")] CaseReview caseReview)
        {
            if (ModelState.IsValid)
            {
                db.CaseReviews.Add(caseReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseReview);
        }

        // GET: CaseReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseReview caseReview = db.CaseReviews.Find(id);
            if (caseReview == null)
            {
                return HttpNotFound();
            }
            return View(caseReview);
        }

        // POST: CaseReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CaseId,ReviewDetails,CreatedBy,CreatedOn")] CaseReview caseReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseReview);
        }

        // GET: CaseReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseReview caseReview = db.CaseReviews.Find(id);
            if (caseReview == null)
            {
                return HttpNotFound();
            }
            return View(caseReview);
        }

        // POST: CaseReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseReview caseReview = db.CaseReviews.Find(id);
            db.CaseReviews.Remove(caseReview);
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
