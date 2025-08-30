using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.DTO.ModuleDTOs
{
    public class AddModuleDTO
    {

        public string ModuleName { get; set; }

        public string Description { get; set; }

        public byte IsActive { get; set; }
    }
}
