using FinalProject.UI.Models.VMs.KonuVM;

namespace FinalProject.UI.Models.VMs.MakaleVM
{
    public class MakaleListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReadingTime { get; set; }
        public int KonuId { get; set; }
    }
}
