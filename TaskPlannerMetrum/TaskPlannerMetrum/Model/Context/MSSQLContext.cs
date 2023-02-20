using Microsoft.EntityFrameworkCore;
using TaskPlannerMetrum.Model.ModelViews;

namespace TaskPlannerMetrum.Model.Context
{
    public class MSSQLContext : DbContext
    {

        public MSSQLContext()
        {

        }
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ActiviesScopeList> ActivitiesScopeList { get; set; }

        public DbSet<ActivityPlan> ActivityPlan { get; set; }

        public DbSet<Department> Department { get; set; }
        public DbSet<DepartmentProjects> DepartmentProjects { get; set; }

        public DbSet<Projects> Projects { get; set; }

        public DbSet<Clients>Clients { get; set; }

        public DbSet<Team> Team { get; set; }
        //Views
        public DbSet<vProjectList> vProjectList { get; set; } 
    }
}
