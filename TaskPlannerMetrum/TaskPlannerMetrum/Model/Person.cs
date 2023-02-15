using System;
using System.ComponentModel.DataAnnotations.Schema;
using TaskPlannerMetrum.Model.Base;

namespace TaskPlannerMetrum.Model
{
    [Table("person")]
    public class Person :  BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("department_id")]
        public long DepartmentId { get; set; }


        [Column("permission_id")]
        public long PermissionId { get; set; }




    }
}
