using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.DTO.PermissionDTOs
{
    public class AddPermissionDTO
    {
        public string PermissionName { get; set; }
        public string Description { get; set; }

        public byte isActive { get; set; }
    }
}
