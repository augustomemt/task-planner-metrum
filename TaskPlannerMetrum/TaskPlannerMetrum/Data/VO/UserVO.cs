using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TaskPlannerMetrum.Data.VO
{
    public class UserVO
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string UserEmail { get; set; }

        public string PhoneNumber { get; set; }
        public long DepartmentId { get; set; }
        public long PermissionId { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
