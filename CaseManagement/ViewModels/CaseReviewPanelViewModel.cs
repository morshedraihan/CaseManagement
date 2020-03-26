using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseManagement.ViewModels
{
    public class CaseReviewPanelViewModel
    {
        public string ReviewDetails { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<CasePanelMemberViewModel> CasePanelMembers { get; set; }
    }
}