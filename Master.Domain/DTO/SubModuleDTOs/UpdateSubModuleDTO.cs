using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.DTO.SubModuleDTOs
{
    public class UpdateSubModuleDTO
    {
        public int SubModuleId { get; set; }
        public string SubModuleName { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public byte IsActive { get; set; }
    }
}
