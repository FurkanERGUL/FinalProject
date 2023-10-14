using FinalProject.CORE.Abstract;
using FinalProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.CORE.Concrete
{
    public class Konu : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;

        //Navigation Property
        public List<Makale> Makales { get; set; }
    }
}
