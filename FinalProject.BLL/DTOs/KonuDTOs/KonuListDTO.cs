using FinalProject.BLL.DTOs.MakaleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTOs.KonuDTOs
{
    public class KonuListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MakaleListDTO> Makales { get; set; }
    }
}
