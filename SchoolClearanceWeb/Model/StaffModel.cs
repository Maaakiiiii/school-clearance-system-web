namespace SchoolClearanceWeb.Model
{
    public class StaffListModel
    {
        public int StaffId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string? CurrentLocation { get; set; }
        public string StaffStatus { get; set; }
        public string OfficeStatus { get; set; }
        public string CrowdStatus { get; set; }
        public string? StaffNote { get; set; }
        public string? AcceptanceWindow { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }

    public class StaffPostModel
    {
        public int PostId { get; set; }
        public int StaffId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; }
    }
}