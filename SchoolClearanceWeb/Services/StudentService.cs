using System.Net.Http.Json;
using SchoolClearanceWeb.Model;

namespace SchoolClearanceWeb.Services
{
    public class StudentService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "http://localhost:5269";

        public StudentService(HttpClient http) { _http = http; }

        // POST /api/studentauth/register
        public async Task<ServiceResponse<string>?> Register(StudentRegisterRequest req)
        {
            var response = await _http.PostAsJsonAsync($"{BaseUrl}/api/studentauth/register", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        // POST /api/studentauth/login
        public async Task<ServiceResponse<TokenResponse>?> Login(StudentLoginRequest req)
        {
            var response = await _http.PostAsJsonAsync($"{BaseUrl}/api/studentauth/login", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<TokenResponse>>();
        }

        // GET /api/student/dashboard/{studentId} — Token: Student
        public async Task<ServiceResponse<StudentDashboardResponse>?> GetDashboard(int studentId, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{BaseUrl}/api/student/dashboard/{studentId}");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<StudentDashboardResponse>>();
        }

        // GET /api/student/profile/{studentId} — Token: Student
        public async Task<ServiceResponse<StudentProfileResponse>?> GetProfile(int studentId, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{BaseUrl}/api/student/profile/{studentId}");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<StudentProfileResponse>>();
        }

        // PUT /api/student/clearance/update — Token: Student
        public async Task<ServiceResponse<string>?> UpdateClearanceItem(UpdateClearanceRequest req, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"{BaseUrl}/api/student/clearance/update");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(req);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        // GET /api/student/offices — No token
        public async Task<ServiceResponse<List<OfficeStatusResponse>>?> GetAllOfficeStatus()
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<OfficeStatusResponse>>>(
                $"{BaseUrl}/api/student/offices");
        }

        // GET /api/student/grade-release-staff — No token  ✅ Bug W5
        public async Task<ServiceResponse<List<GradeReleaseStaffModel>>?> GetGradeReleaseStaff()
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<GradeReleaseStaffModel>>>(
                $"{BaseUrl}/api/student/grade-release-staff");
        }

        // GET /api/student/posts/all — No token
        public async Task<ServiceResponse<List<StaffPostModel>>?> GetAllPosts()
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<StaffPostModel>>>(
                $"{BaseUrl}/api/student/posts/all");
        }

        // GET /api/student/staff/{staffId} — No token
        public async Task<ServiceResponse<StaffListModel>?> GetStaffById(int staffId)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<StaffListModel>>(
                $"{BaseUrl}/api/student/staff/{staffId}");
        }

        // GET /api/student/staff/search?name=... — No token
        public async Task<ServiceResponse<List<StaffListModel>>?> SearchStaff(string name)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<StaffListModel>>>(
                $"{BaseUrl}/api/student/staff/search?name={Uri.EscapeDataString(name)}");
        }

        // GET /api/adminclearance/get-schedule — No token (public)
        public async Task<ServiceResponse<ClearanceScheduleResponse>?> GetClearanceSchedule()
        {
            return await _http.GetFromJsonAsync<ServiceResponse<ClearanceScheduleResponse>>(
                $"{BaseUrl}/api/adminclearance/get-schedule");
        }

        // PUT /api/studentauth/change-password/{studentId} — Token: Student  ✅ ProfilePage
        public async Task<ServiceResponse<string>?> ChangePassword(int studentId, string currentPassword, string newPassword, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"{BaseUrl}/api/studentauth/change-password/{studentId}");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(new
            {
                CurrentPassword = currentPassword,
                NewPassword = newPassword
            });
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}