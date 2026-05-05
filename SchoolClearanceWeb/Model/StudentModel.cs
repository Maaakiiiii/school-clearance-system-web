namespace SchoolClearanceWeb.Model
{
    public class StudentDashboardResponse
    {
        public int StudentId { get; set; }
        public string Username { get; set; }
        public string StudentNo { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public int ClearanceProgress { get; set; }
        public List<ClearanceItemModel> ClearanceItems { get; set; }
    }

    public class StudentProfileResponse
    {
        public int StudentId { get; set; }
        public string Username { get; set; }
        public string StudentNo { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
    }

    public class ClearanceScheduleResponse
    {
        public int ScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class OfficeStatusResponse
    {
        public int StaffId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string? CurrentLocation { get; set; }
        public string OfficeStatus { get; set; }
        public string CrowdStatus { get; set; }
        public string? StaffNote { get; set; }
        public string? AcceptanceWindow { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string? StaffStatus { get; set; }  // ✅ Bug W4 fix
        public string? ProfilePicture { get; set; } // ✅ Item 7 — from SP_GetAllStaff
    }
}