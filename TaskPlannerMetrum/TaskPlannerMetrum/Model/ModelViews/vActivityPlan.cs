using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaskPlannerMetrum.Model.ModelViews
{
    public class vActivityPlan
    {
        [Key]
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public string Description { get; set; }

        public int ActivitiesScopeListID { get; set; }

        public DateTime ScheduledDate { get; set; }

        public int PlannedManHour { get; set; }

        public int PlannerTeamID { get; set; }

        public string NotesFromPlanner { get; set; }

        public int ExecutorTeamID { get; set; }

        public char Status { get; set; }    

        public int ExecutedManHour { get; set; }

        public string NotesFromExecutor { get; set; }

        public int UserID { get; set; }

        public string ExecutorName { get; set; }

        public string statusName { get; set; }

    }
}
