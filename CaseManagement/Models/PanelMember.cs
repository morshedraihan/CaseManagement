using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseManagement.Models
{
    public class PanelMember
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}