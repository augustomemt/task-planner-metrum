using System.Collections.Generic;
using TaskPlannerMetrum.Model.ModelViews;

namespace TaskPlannerMetrum.Repository.Projects
{
    public interface IProjectsRepository
    {
        public List<vProjectList> GetAllProjects();
    }
}
