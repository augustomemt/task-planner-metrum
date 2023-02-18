using System;
using System.ComponentModel.DataAnnotations;
using TaskPlannerMetrum.Model.Base;

namespace TaskPlannerMetrum.Model
{
    public class Projects 
    {
       
        public int ID { get; set; }
        public string Name { get; set; }
        public string InternalCode { get; set; }
        public int ClientID { get; set; }
        public int WorkspaceID { get; set; }
        public float? PlannedManHour { get; set; }
        public float? ExecutedManHour { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ContractEndDate { get; set;}
        public DateTime? EndDate { get; set;}
        public int PMTeamID { get; set; }
    }
}
