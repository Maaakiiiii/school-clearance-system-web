using System.Net.Http.Json;
using SchoolClearanceWeb.Model;

namespace SchoolClearanceWeb.Services
{
    public class StudentService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "http://localhost:5269";

        public StudentService(HttpClient http) { _http = http; }

        // POST /api/studentauth/register — No token
        public async Task<ServiceResponse<string>?> Register(StudentRegisterRequest req)
        {
            var response = await _http.PostAsJsonAsync($"{BaseUrl}/api/studentauth/register", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        // POST /api/studentauth/login — No token
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
            return await response.Content
                .ReadFromJsonAsync<ServiceResponse<StudentDashboardResponse>>();
        }

        // GET /api/student/profile/{studentId} — Token: Student
        public async Task<ServiceResponse<StudentProfileResponse>?> GetProfile(int studentId, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{BaseUrl}/api/student/profile/{studentId}");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content
                .ReadFromJsonAsync<ServiceResponse<StudentProfileResponse>>();
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

        // GET /api/student/posts/all — No token
        public async Task<ServiceResponse<List<StaffPostModel>>?> GetAllPosts()
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<StaffPostModel>>>(
                $"{BaseUrl}/api/student/posts/all");
        }
    }
}
