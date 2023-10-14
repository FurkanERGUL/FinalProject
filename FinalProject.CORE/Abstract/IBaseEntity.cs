using FinalProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.CORE.Abstract
{
    public interface IBaseEntity
    {
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }

    }
}
