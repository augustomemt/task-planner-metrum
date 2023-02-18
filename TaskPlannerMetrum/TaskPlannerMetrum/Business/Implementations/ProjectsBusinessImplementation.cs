using System;
using System.Linq;
using TaskPlannerMetrum.Data.Converter.Implementations;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.DTO;
using TaskPlannerMetrum.Repository.Generic;
using TaskPlannerMetrum.Repository.Projects;

namespace TaskPlannerMetrum.Business.Implementations
{
    public class ProjectsBusinessImplementation : IProjectsBusiness
    {

        private readonly IProjectsRepository _projectRepository;
        private readonly IUserBusiness _userBusiness;

        

        public ProjectsBusinessImplementation( IProjectsRepository projectsRepository, IUserBusiness userBusiness)
        {
             _projectRepository= projectsRepository;
            _userBusiness= userBusiness;
         
        }
        public Projects Create(ProjectDTO projects)
        {
            Projects newProject = new Projects
            {
                ClientID = Convert.ToInt32(projects.clientID),
                StartDate = Convert.ToDateTime(projects.startDate),
                ContractEndDate = Convert.ToDateTime(projects.contractEndDate),
                Name = projects.projectName,
                PMTeamID = Convert.ToInt32(projects.PMTeamID),
                InternalCode = projects.internalCode,
                PlannedManHour = float.Parse(projects.plannedManHour),
                WorkspaceID = 1
                
            };
            return _projectRepository.Create(newProject);
            
        }

        public dynamic FindAll()
        {
            try
            {
                return _projectRepository.GetAllProjects().Select(s => new { s.ProjectName, s.ClientName, s.PlannedManHour, s.StartDate, s.DepartmentName, s.ProjectID });
            }
            catch (Exception e)
            {
                return e;
            }
            
        }

        public dynamic FindPlannerManager()
        {
            return _userBusiness.FindAll().Where(u => u.DepartmentId == 4).Select(u => new {u.Id , u.FullName}).OrderBy(u => u.FullName).ToList();
        }

        

        
    }
}
