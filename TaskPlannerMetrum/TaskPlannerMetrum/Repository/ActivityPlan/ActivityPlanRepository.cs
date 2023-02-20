using System;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.Context;
using TaskPlannerMetrum.Model.DTO;

namespace TaskPlannerMetrum.Repository.ActivityPlan
{
    public class ActivityPlanRepository : IActivityPlanRepository
    {
        private MSSQLContext _context;

        public ActivityPlanRepository(MSSQLContext context) { _context = context; }

        public bool Create(Model.ActivityPlan activityPlan)
        {
            try
            {
                _context.ActivityPlan.Add(new Model.ActivityPlan
                {
                    ActivitiesScopeListID = activityPlan.ActivitiesScopeListID,
                    ExecutedManHour = activityPlan.ExecutedManHour,
                    ExecutorTemID = activityPlan.ExecutorTemID,
                    NotesFromExecutor = activityPlan.NotesFromExecutor,
                    NotesFromPlanner = activityPlan.NotesFromPlanner,
                    PlannedManHour = activityPlan.PlannedManHour,
                    PlannerTeamID = activityPlan.PlannerTeamID,
                    ProjectID = activityPlan.ProjectID,
                    ScheduledDate = activityPlan.ScheduledDate,
                    Status = activityPlan.Status,
                    WorkspaceID = activityPlan.WorkspaceID,

                });
                _context.SaveChanges();
                return true;
                   
            }
            catch
            {
                return false;
            }
        }

        public dynamic GetExecutorPlan(string projectId)
        {
           List<ExecutorDTO> ExecutorPlans = new List<ExecutorDTO>();
            try
            {
                 var departments =  _context.DepartmentProjects.Where( p => p.ProjectID == Convert.ToInt32(projectId)).ToList();
                 foreach(var department in departments)
                 {
                    var usersTeam = _context.Team.Where(u => u.DepartmentID == department.DepartmentID).ToList();

                    foreach(var user in usersTeam)
                    {
                        var userExecutor = _context.Users.Where(u => u.ID == user.UserID).FirstOrDefault();

                        if(userExecutor!= null)
                        {

                            ExecutorPlans.Add(new ExecutorDTO { Name = userExecutor.FullName , pmTeamID = user.UserID});
                        }
                        

                        
                    }

                 }

                return ExecutorPlans;
            }
            catch 
            {
                return null;
            }
        }
    }
}
