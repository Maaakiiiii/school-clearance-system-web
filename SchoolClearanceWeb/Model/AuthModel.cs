namespace SchoolClearanceWeb.Model
{
    public class StudentLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class StudentRegisterRequest
    {
        public string StudentNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string CourseStrand { get; set; }  // ✅ Fixed (was Course)
        public string YearLevel { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
        public int StudentId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
