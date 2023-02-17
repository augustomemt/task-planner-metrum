﻿using TaskPlannerMetrum.Model.Base;

namespace TaskPlannerMetrum.Model
{
    public class Team : BaseEntity
    {
        public int DepartmentID { get; set; }
        public string SeniorityLevel { get; set; }

        public string WorkForceClass { get; set; }
        public string WorkForceType { get; set;}    

        public decimal HoursAvailability { get; set; }

        public decimal  ManHourCost { get; set; }

        public int UserID { get; set; }

        public bool isLeader { get; set; }
    }
}
