using System;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.Context;

namespace TaskPlannerMetrum.Repository.ActiviesScope
{
    public class ActiviesScopeRepository : IActiviesRepository
    {
        private MSSQLContext _context;

        public ActiviesScopeRepository(MSSQLContext context) { _context = context; }
        public List<ActiviesScopeList> GetActiviesScopeByProject(string ProectID)
        {
            List<ActiviesScopeList> activiesScopeLists = new List<ActiviesScopeList>();
            try
            {
                

                var departmentList = _context.DepartmentProjects.Where(p => p.ProjectID == Convert.ToInt32(ProectID)).Select(s => s.DepartmentID).ToList();                
                foreach(var department in departmentList)
                {
                    var actives = _context.ActivitiesScopeList.Where(a => a.DepartmentID == department).ToList();

                    activiesScopeLists.AddRange(actives);
                }

                return activiesScopeLists;

            }
            catch 
            {
                return activiesScopeLists;

            }
        }
    }
}
