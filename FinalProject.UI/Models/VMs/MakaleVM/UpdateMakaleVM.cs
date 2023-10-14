using FinalProject.UI.Models.VMs.KonuVM;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalProject.UI.Models.VMs.MakaleVM
{
    public class UpdateMakaleVM
    {
        public int Id { get; set; }
        [Display(Name = "Makale Başlığını giriniz")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Makale İçeriğini giriniz")]
        [Required]
        public string Content { get; set; }

        public List<KonuListVM> Konular { get; set; }
        public int KonuId { get; set; }
    }
}
