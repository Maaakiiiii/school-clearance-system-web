namespace SchoolClearanceWeb.Model
{
    public class StudentLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class StudentRegisterRequest
    {
        public string StudentNo { get; set; }  // School ID number
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public string Department { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
        public int StudentId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}