using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace TaskPlannerMetrum.Data.VO
{
    public class PersonVO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public string PhoneNumber { get; set; } 
        public long DepartmentId { get; set; }        
        public long PermissionId { get; set; }

    }
}
