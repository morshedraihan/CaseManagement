using CaseManagement.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CaseManagement.DataAccess
{
    public class CaseContext : DbContext
    {
        public CaseContext() : base("DefaultConnection") { }

        public DbSet<Case> Cases { get; set; }
        public DbSet<PanelMember> PanelMembers { get; set; }
        public DbSet<CasePanelMember> CasePanelMembers { get; set; }
        public DbSet<CaseReview> CaseReviews { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<CaseContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }
    }
}