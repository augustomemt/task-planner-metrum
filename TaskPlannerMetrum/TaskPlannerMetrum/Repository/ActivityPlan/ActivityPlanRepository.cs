using System;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.Context;
using TaskPlannerMetrum.Model.DTO;
using TaskPlannerMetrum.Model.ModelViews;

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
                _context.Add(new Model.ActivityPlan
                {
                    ActivitiesScopeListID = activityPlan.ActivitiesScopeListID,
                    ExecutedManHour = activityPlan.ExecutedManHour,
                    ExecutorTeamID = activityPlan.ExecutorTeamID,
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

        public List<vActivityPlan> FindAllTaskByProject(string projectId)
        {
            List<vActivityPlan>_activityPlans= new List<vActivityPlan>();
            var taskPlans = _context.ActivityPlan.Where(a => a.ProjectID == Convert.ToInt32(projectId)).ToList();

            foreach(var taskPlan in taskPlans)
            {
                 var userid = _context.Team.Where( t => t.ID == taskPlan.ExecutorTeamID).Select(s => s.UserID).FirstOrDefault();
                _activityPlans.Add(new vActivityPlan
                {
                    ActivitiesScopeListID = taskPlan.ActivitiesScopeListID,
                    Description = _context.ActivitiesScopeList.Where(d => d.ID == Convert.ToInt32(taskPlan.ActivitiesScopeListID)).Select(s => s.Description).FirstOrDefault(),
                    ExecutedManHour = taskPlan.ExecutedManHour,
                    ExecutorName = _context.Users.Where(u => u.Id == userid).Select(s => s.FullName).FirstOrDefault(),
                    ExecutorTeamID = taskPlan.ExecutorTeamID,
                    NotesFromExecutor = taskPlan.NotesFromExecutor,
                    NotesFromPlanner = taskPlan.NotesFromPlanner,
                    PlannedManHour = taskPlan.PlannedManHour,
                    PlannerTeamID = taskPlan.PlannerTeamID,
                    ProjectID = taskPlan.ProjectID,
                    ScheduledDate = taskPlan.ScheduledDate,
                    Status = taskPlan.Status,
                    ID= taskPlan.ID,
                    statusName = GetStatusName(taskPlan.Status.ToString())

                });
            }

            return _activityPlans;
        }

        public static string GetStatusName(string status)
        {
            switch (status)
            {
                case "5":
                    return "Não Iniciada";                
                case "1":
                    return "Concluída";
                case "2":
                    return "Em progresso";
                case "3":
                    return "Bloqueada";               

            }
            return "Não iniciada";
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
