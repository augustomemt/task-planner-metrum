using System.ComponentModel.DataAnnotations;
using TaskPlannerMetrum.Model.Base;

namespace TaskPlannerMetrum.Model
{
    public class Department : BaseEntity
    {
        
        public string Name { get; set; }
        public int WorkspaceID { get; set; }
        public string CostCenter { get; set; }

    }
}
