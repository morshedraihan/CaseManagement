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
    public class PanelMemberController : Controller
    {
        private PanelMemberService panelMemberService = new PanelMemberService();

        // GET: PanelMembers
        public ActionResult Index()
        {
            return View(panelMemberService.GetAll());
        }

        // GET: PanelMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanelMember panelMember = panelMemberService.GetById(id);
            if (panelMember == null)
            {
                return HttpNotFound();
            }
            return View(panelMember);
        }

        // GET: PanelMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanelMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] PanelMember @panelMember)
        {
            if (ModelState.IsValid)
            {
                panelMemberService.AddNew(@panelMember);
                return RedirectToAction("Index");
            }

            return View(@panelMember);
        }

        // GET: PanelMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanelMember panelMember = panelMemberService.GetById(id);
            if (panelMember == null)
            {
                return HttpNotFound();
            }
            return View(panelMember);
        }

        // POST: PanelMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] PanelMember panelMember)
        {
            if (ModelState.IsValid)
            {
                panelMemberService.Edit(panelMember);
                return RedirectToAction("Index");
            }
            return View(panelMember);
        }

        // GET: PanelMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanelMember panelMember = panelMemberService.GetById(id);
            if (panelMember == null)
            {
                return HttpNotFound();
            }
            return View(panelMember);
        }

        // POST: PanelMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            panelMemberService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
