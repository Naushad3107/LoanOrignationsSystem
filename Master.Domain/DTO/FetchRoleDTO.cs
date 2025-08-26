﻿using LOSApplicationApi.Model;

namespace LOSApplicationApi.DTO
{
    public class FetchRoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}
