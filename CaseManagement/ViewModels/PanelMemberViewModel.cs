using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseManagement.ViewModels
{
    public class PanelMemberViewModel
    {
        public bool MemberSelected { get; set; }
        public int PanelMemberId { get; set; }
        public string PanelMemberName { get; set; }
    }
}