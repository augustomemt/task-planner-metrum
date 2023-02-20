using System.ComponentModel.DataAnnotations;

namespace TaskPlannerMetrum.Model
{
    public class DepartmentProjects
    {
        [Key]
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int DepartmentID { get; set; }

    }
}
