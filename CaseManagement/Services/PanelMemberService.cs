using CaseManagement.DataAccess;
using CaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaseManagement.Services
{
    public class PanelMemberService
    {
        private CaseContext db = new CaseContext();
        public List<PanelMember> GetAll()
        {
            return db.PanelMembers.ToList();
        }

        public PanelMember GetById(int? id)
        {
            return db.PanelMembers.Find(id);
        }

        public void AddNew(PanelMember @panelMember)
        {
            db.PanelMembers.Add(@panelMember);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            PanelMember @panelMember = db.PanelMembers.Find(id);
            db.PanelMembers.Remove(@panelMember);
            db.SaveChanges();
        }

        public void Edit(PanelMember @panelMember)
        {
            db.Entry(@panelMember).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}