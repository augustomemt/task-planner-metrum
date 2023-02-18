using System.Collections.Generic;

namespace TaskPlannerMetrum.Model.DTO
{
    public class ProjectDTO
    {
        public string projectName { get; set; }
        public string clientID { get; set; }

        public string plannedManHour { get; set; }

        public string startDate { get; set; }

        public string contractEndDate { get; set; }

        public List<string> dapartment { get; set; }

        public string internalCode { get; set; }

        public string PMTeamID { get; set; }

   
    }
}
