using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTOs.MakaleDTOs
{
    public class MakaleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int KonuId { get; set; }
        public string WriterName { get; set; }
        public DateTime PublishDate { get; set; }
        public int ReadingTime { get; set; }
    }
}
