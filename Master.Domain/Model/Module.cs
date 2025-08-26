using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Domain.Model
{
    public  class Module
    {

        [Key]
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }

        public string Description { get; set; }

        public byte IsActive { get; set; }

        public byte IsDeleted { get; set; }

    }
}
