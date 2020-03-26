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
        public string ReviewDetails { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}