using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseManagement.Models
{
    public class Case
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Case Title")]
        public string Title { get; set; }
        [Display(Name = "Case Description")]
        public string Description { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}