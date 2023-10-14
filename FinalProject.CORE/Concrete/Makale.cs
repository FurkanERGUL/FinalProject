using FinalProject.CORE.Abstract;
using FinalProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.CORE.Concrete
{
    public class Makale : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int ReadingTime { get; set; }
        public string WriterName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;

        //Navigation Property
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public Konu Konu { get; set; }
        public int KonuId { get; set; }

    }
}
