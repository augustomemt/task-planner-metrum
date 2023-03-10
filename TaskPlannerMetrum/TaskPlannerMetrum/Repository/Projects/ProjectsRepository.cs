using System.Collections.Generic;
using System.Linq;
using TaskPlannerMetrum.Model.Context;
using TaskPlannerMetrum.Model.ModelViews;
using TaskPlannerMetrum.Model;
using System.Data;
using System;

namespace TaskPlannerMetrum.Repository.Projects
{
    public class ProjectsRepository : IProjectsRepository
    {
        private MSSQLContext _context;

        public ProjectsRepository(MSSQLContext context) { _context = context; }

        public bool Create(Model.Projects newProject)
        {
            try
            {
                _context.Add(newProject);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<vProjectList> GetAllProjects()
        {
            return _context.vProjectList.ToList();
        }
       
    }
}
