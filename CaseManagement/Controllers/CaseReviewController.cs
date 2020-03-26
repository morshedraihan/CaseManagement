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
using CaseManagement.Services;
using CaseManagement.ViewModels;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class CaseReviewController : Controller
    {
        //private CaseContext db = new CaseContext();
        private CaseReviewService caseReviewService = new CaseReviewService();

        // GET: CaseReviews
        public ActionResult Index()
        {
            return View(caseReviewService.GetAll());
        }

        // GET: CaseReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseReview caseReview = caseReviewService.GetById(id);
            if (caseReview == null)
            {
                return HttpNotFound();
            }
            return View(caseReview);
        }

        // GET: CaseReviews/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult Create()
        {
            return View(caseReviewService.GetAllCaseReviewPanels());
        }


        // POST: CaseReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CaseReviewPanelViewModel test)
        {
            if (ModelState.IsValid)
            {
                //caseReviewService.AddCaseReview(caseReview);
                var abc = test.CasePanelMembers;
                //return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //public ActionResult Create([Bind(Include = "Id,CaseId,ReviewDetails,CreatedBy,CreatedOn")] CaseReview caseReview)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        caseReviewService.AddCaseReview(caseReview);
        //        return RedirectToAction("Index");
        //    }

        //    return View(caseReview);
        //}

        // GET: CaseReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseReview caseReview = caseReviewService.GetById(id);
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
                caseReviewService.UpdateCaseReview(caseReview);
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
            CaseReview caseReview = caseReviewService.GetById(id);
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
            caseReviewService.DeleteCaseReview(id);
            return RedirectToAction("Index");
        }
    }
}
