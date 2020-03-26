using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseManagement.ViewModels
{
    public class CasePanelMemberViewModel
    {
        public bool CaseSelected { get; set; }
        public int CaseId { get; set; }
        public string CaseTitle { get; set; }
        public string ReviewDetails { get; set; }
        public List<PanelMemberViewModel> AllPanelMembers { get; set; }
    }
}