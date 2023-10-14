using FinalProject.BLL.DTOs.MakaleDTOs;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalProject.UI.Models.VMs.KonuVM
{
    public class UpdateKonuVM
    {
        [Required]
        [Display(Name = "Konu Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Konu adı")]
        public string Name { get; set; }
    }
}
