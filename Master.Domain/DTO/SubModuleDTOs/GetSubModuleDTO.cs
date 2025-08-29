using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.DTO.SubModuleDTOs
{
    public class GetSubModuleDTO
    {

        public int SubModuleId { get; set; }

        public string SubModuleName { get; set; }

        public string Description { get; set; }

        
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }

        public byte IsActive { get; set; }

    }
}
