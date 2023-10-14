using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTOs.MakaleDTOs
{
    public class MakaleListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReadingTime { get; set; }
        public int KonuId { get; set; }
    }
}
