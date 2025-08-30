using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.DTO.SubModuleDTOs
{
    public class AddSubModuleDTO
    {
        public string SubModuleName { get; set; }

        public string Description { get; set; }

       
        public int ModuleId { get; set; }

        public byte IsActive { get; set; }
    }
}
