using System;
using System.ComponentModel.DataAnnotations;

namespace TaskPlannerMetrum.Model
{
    public class ActivityPlan
    {
        [Key] 
        public int ID { get; set; }

        public int WorkspaceID {get;set;}

        public int ProjectID { get; set; }
        public int ActivitiesScopeListID { get; set; }

        public DateTime ScheduledDate { get; set; }

        public int PlannedManHour { get; set; }

        public int PlannerTeamID { get; set; }

        public string NotesFromPlanner { get; set; }

        public int ExecutorTeamID { get; set; }

        public char Status { get; set; }    

        public int ExecutedManHour { get; set; }

        public string NotesFromExecutor { get; set; }

    }
}
