using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalProject.UI.Models.VMs.KonuVM
{
    public class CreateKonuVM
    {
        [Required]
        [Display(Name = "Konu başlığını giriniz.")]
        public string Name { get; set; }

    }
}
