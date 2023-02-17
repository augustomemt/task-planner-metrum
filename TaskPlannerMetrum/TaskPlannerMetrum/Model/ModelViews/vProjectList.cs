using System;
using System.ComponentModel.DataAnnotations;

namespace TaskPlannerMetrum.Model.ModelViews
{
    public class vProjectList
    {
        [Key]
        public int ProjectID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public int DepartmentID { get; set; }
        public double PlannedManHour { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PMTeamID { get; set; }
        public string DepartmentName { get; set; }

    } 
}
