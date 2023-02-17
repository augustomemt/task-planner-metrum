using System.Collections.Generic;
using System.Linq;
using TaskPlannerMetrum.Model.Context;
using TaskPlannerMetrum.Model.ModelViews;

namespace TaskPlannerMetrum.Repository.Projects
{
    public class ProjectsRepository : IProjectsRepository
    {
        private MSSQLContext _context;

        public ProjectsRepository(MSSQLContext context) { _context = context; }
        public List<vProjectList> GetAllProjects()
        {
            return _context.vProjectList.ToList();
        }
    }
}
