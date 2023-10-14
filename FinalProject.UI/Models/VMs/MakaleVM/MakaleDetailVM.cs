namespace FinalProject.UI.Models.VMs.MakaleVM
{
    public class MakaleDetailVM
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
