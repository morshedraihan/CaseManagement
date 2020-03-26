using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseManagement.Models
{
    public class CaseReview
    {
        [Key]
        public int Id { get; set; }
        public int CaseId { get; set; }
        [Display(Name = "Case Title")]
        public string CaseTitle { get; set; }
        [Display(Name = "Review Details")]
        public string ReviewDetails { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}