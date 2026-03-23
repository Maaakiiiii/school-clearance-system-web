namespace SchoolClearanceWeb.Model
{
    public class StudentDashboardModel
    {
        public int StudentId { get; set; }
        public string Username { get; set; }
        public string StudentNo { get; set; }
        public string FullName { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public int ClearanceProgress { get; set; }  // percentage 0-100
        public List<ClearanceItemModel> ClearanceItems { get; set; }
    }
}