﻿using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TaskPlannerMetrum.Data.VO
{
    public class UserVO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string UserEmail { get; set; }

        public string PhoneNumber { get; set; }
        public int WorkspaceID { get; set; }
        public int DepartmentId { get; set; }
        public int PermissionId { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
