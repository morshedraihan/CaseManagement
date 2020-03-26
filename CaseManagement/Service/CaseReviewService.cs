using CaseManagement.DataAccess;
using CaseManagement.Models;
using CaseManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseManagement.Service
{
    public class CaseReviewService
    {
        private CaseContext db = new CaseContext();
        public CaseReviewPanelViewModel GetAllCaseReviewPanels()
        {
            CaseReviewPanelViewModel caseReviewPanels = new CaseReviewPanelViewModel();
            caseReviewPanels.CasePanelMembers = new List<CasePanelMemberViewModel>();
            var allPanelMembers = db.PanelMembers.ToList();
            var allCases = db.Cases.ToList();

            foreach (var currentCase in allCases)
            {
                var casePanelMemberViewModel = new CasePanelMemberViewModel();
                casePanelMemberViewModel.CaseId = currentCase.Id;
                casePanelMemberViewModel.CaseTitle = currentCase.Title;
                casePanelMemberViewModel.ReviewDetails = db.CaseReviews
                                                    .Where(rev => rev.CaseId == currentCase.Id)
                                                    .FirstOrDefault<CaseReview>().ReviewDetails;
                var allPanelMembersViewModel = new List<PanelMemberViewModel>();
                foreach (var currentPanelMember in allPanelMembers)
                {
                    var panelMemberViewModel = new PanelMemberViewModel();
                    panelMemberViewModel.PanelMemberId = currentPanelMember.Id;
                    panelMemberViewModel.PanelMemberName = currentPanelMember.Name;
                    var panelMember = db.CasePanelMembers.Where(mem => mem.CaseId == currentCase.Id 
                                                                    && mem.PanelMemberId == currentPanelMember.Id)
                                                         .FirstOrDefault<CasePanelMember>();
                    panelMemberViewModel.MemberSelected = (panelMember == null)? false: true;
                }

                casePanelMemberViewModel.AllPanelMembers = allPanelMembersViewModel;
                caseReviewPanels.CasePanelMembers.Add(casePanelMemberViewModel);
            }
            return caseReviewPanels;
        }
    }
}