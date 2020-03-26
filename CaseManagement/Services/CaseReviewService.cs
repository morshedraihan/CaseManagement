using CaseManagement.DataAccess;
using CaseManagement.Models;
using CaseManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaseManagement.Services
{
    public class CaseReviewService
    {
        private CaseContext db = new CaseContext();
        public CaseReviewPanelViewModel GetAllCaseReviewPanels()
        {
            CaseReviewPanelViewModel caseReviewPanels = new CaseReviewPanelViewModel
            {
                CasePanelMembers = new List<CasePanelMemberViewModel>()
            };
            var allPanelMembers = db.PanelMembers.ToList();
            var allCases = db.Cases.ToList();

            foreach (var currentCase in allCases)
            {
                var casePanelMemberViewModel = new CasePanelMemberViewModel
                {
                    CaseId = currentCase.Id,
                    CaseTitle = currentCase.Title,
                    ReviewDetails = db.CaseReviews
                                      .Where(rev => rev.CaseId == currentCase.Id)
                                      .FirstOrDefault<CaseReview>()?.ReviewDetails
                };
                var allPanelMembersViewModel = new List<PanelMemberViewModel>();
                foreach (var currentPanelMember in allPanelMembers)
                {
                    var panelMemberViewModel = new PanelMemberViewModel
                    {
                        PanelMemberId = currentPanelMember.Id,
                        PanelMemberName = currentPanelMember.Name
                    };
                    var panelMember = db.CasePanelMembers.Where(mem => mem.CaseId == currentCase.Id 
                                                                    && mem.PanelMemberId == currentPanelMember.Id)
                                                         .FirstOrDefault<CasePanelMember>();
                    panelMemberViewModel.MemberSelected = (panelMember == null)? false: true;
                    allPanelMembersViewModel.Add(panelMemberViewModel);
                }

                casePanelMemberViewModel.AllPanelMembers = allPanelMembersViewModel;
                caseReviewPanels.CasePanelMembers.Add(casePanelMemberViewModel);
            }
            return caseReviewPanels;
        }
        public List<CaseReview> GetAll()
        {
            return db.CaseReviews.ToList();
        }
        public CaseReview GetById(int? id)
        {
            return db.CaseReviews.Find(id);
        }
        public void AddCaseReview(CaseReview caseReview)
        {
            db.CaseReviews.Add(caseReview);
            db.SaveChanges();
        }
        public void UpdateCaseReview(CaseReview caseReview)
        {
            db.Entry(caseReview).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteCaseReview(int id)
        {
            CaseReview caseReview = db.CaseReviews.Find(id);
            db.CaseReviews.Remove(caseReview);
            db.SaveChanges();
        }
    }
}