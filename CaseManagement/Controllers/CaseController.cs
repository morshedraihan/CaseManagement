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
using CaseManagement.Service;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class CaseController : Controller
    {
        private CaseService caseService = new CaseService();

        // GET: Case
        public ActionResult Index()
        {
            return View(caseService.GetAll());
        }

        // GET: Case/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = caseService.GetById(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Case/Create
        public ActionResult Create()
        {
            Case @case = new Case();
            @case.CreatedBy = User.Identity.Name;
            @case.CreatedOn = System.DateTime.Now;
            return View(@case);
        }

        // POST: Case/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,CreatedBy,CreatedOn")] Case @case)
        //public ActionResult Create([Bind(Include = "Id,Title,Description")] Case @case)
        {
            if (ModelState.IsValid)
            {
                caseService.AddNew(@case);
                return RedirectToAction("Index");
            }

            return View(@case);
        }

        // GET: Case/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = caseService.GetById(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Case/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,CreatedBy,CreatedOn")] Case @case)
        {
            if (ModelState.IsValid)
            {
                caseService.Edit(@case);
                return RedirectToAction("Index");
            }
            return View(@case);
        }

        // GET: Case/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = caseService.GetById(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Case/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            caseService.DeleteById(id);
            return RedirectToAction("Index");
        }


    }
}
