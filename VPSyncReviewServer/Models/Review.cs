namespace VPSyncReviewServer.Models
{
    public class Review //손글씨 기록 한 건
    {
        public int Id { get; set; }

        public string ShotName { get; set; } = string.Empty;

        public string DrawingData { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int Frame { get; set; }
    }
}
