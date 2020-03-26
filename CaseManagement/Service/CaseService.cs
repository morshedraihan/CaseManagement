using CaseManagement.DataAccess;
using CaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaseManagement.Service
{
    public class CaseService
    {
        private CaseContext db = new CaseContext();
        public List<Case> GetAll()
        {
            return db.Cases.ToList();
        }

        public Case GetById(int? id)
        {
            return db.Cases.Find(id);
        }

        public void AddNew(Case @case)
        {
            db.Cases.Add(@case);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
            db.SaveChanges();
        }

        public void Edit(Case @case)
        {
            db.Entry(@case).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}