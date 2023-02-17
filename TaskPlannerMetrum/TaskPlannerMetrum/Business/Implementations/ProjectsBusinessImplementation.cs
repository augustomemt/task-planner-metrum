using System.Linq;
using TaskPlannerMetrum.Data.Converter.Implementations;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Repository.Generic;
using TaskPlannerMetrum.Repository.Projects;

namespace TaskPlannerMetrum.Business.Implementations
{
    public class ProjectsBusinessImplementation : IProjectsBusiness
    {
        

        private readonly IProjectsRepository _projectRepository;

        

        public ProjectsBusinessImplementation( IProjectsRepository projectsRepository)
        {
             _projectRepository= projectsRepository;
            
            
        }
        public Projects Create(Projects projects)
        {
            throw new System.NotImplementedException();
        }

        public dynamic FindAll()
        {
            return _projectRepository.GetAllProjects().Select(s => new { s.ProjectName, s.ClientName, s.PlannedManHour, s.StartDate, s.DepartmentName, s.ProjectID});
        }

        

        public dynamic FindPlannerManager()
        {
            throw new System.NotImplementedException();
        }
    }
}
