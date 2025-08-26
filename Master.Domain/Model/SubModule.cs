using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.Model
{
    public class SubModule
    {
        [Key]
        public int SubModuleId { get; set; }

        public string SubModuleName { get; set; }

        public string Description { get; set; }

        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        public byte IsActive { get; set; }


        //navigation property
        public Module Module { get; set; }


        public List<RolePermissions> RolePermissions { get; set; }

    }
}
