using System.Net.Http.Json;
using SchoolClearanceWeb.Model;

namespace SchoolClearanceWeb.Services
{
    public class AdminService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "http://localhost:5269";

        public AdminService(HttpClient http) { _http = http; }

        // POST /api/adminauth/login — No token
        public async Task<ServiceResponse<TokenResponse>?> Login(AdminLoginRequest req)
        {
            var response = await _http.PostAsJsonAsync($"{BaseUrl}/api/adminauth/login", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<TokenResponse>>();
        }

        // POST /api/admincoupon/generate — Token: Admin
        public async Task<ServiceResponse<CouponResponse>?> GenerateCoupon(GenerateCouponRequest req, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"{BaseUrl}/api/admincoupon/generate");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(req);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<CouponResponse>>();
        }

        // GET /api/admincoupon/all — Token: Admin
        public async Task<ServiceResponse<List<GetAllCouponsResponse>>?> GetAllCoupons(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{BaseUrl}/api/admincoupon/all");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<GetAllCouponsResponse>>>();
        }

        // POST /api/admincoupon/validate — No token
        public async Task<ServiceResponse<string>?> ValidateCoupon(object req)
        {
            var response = await _http.PostAsJsonAsync($"{BaseUrl}/api/admincoupon/validate", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        // GET /api/adminstaff/teachers — Token: Admin
        public async Task<ServiceResponse<List<StaffListModel>>?> GetAllTeachers(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{BaseUrl}/api/adminstaff/teachers");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<StaffListModel>>>();
        }

        // GET /api/staff/all — Token: Admin
        public async Task<ServiceResponse<List<StaffListModel>>?> GetAllStaff(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{BaseUrl}/api/staff/all");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<StaffListModel>>>();
        }

        // PUT /api/adminstaff/assign-grade-release/{staffId} — Token: Admin
        public async Task<ServiceResponse<string>?> AssignGradeRelease(int staffId, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"{BaseUrl}/api/adminstaff/assign-grade-release/{staffId}");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        // PUT /api/adminstaff/revoke-grade-release/{staffId} — Token: Admin
        public async Task<ServiceResponse<string>?> RevokeGradeRelease(int staffId, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"{BaseUrl}/api/adminstaff/revoke-grade-release/{staffId}");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        // GET /api/admin/clearance-schedule — Token: Admin
        public async Task<ServiceResponse<ClearanceSchedule>?> GetClearanceSchedule(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{BaseUrl}/api/admin/clearance-schedule");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<ClearanceSchedule>>();
        }

        // POST /api/admin/clearance-schedule — Token: Admin
        public async Task<ServiceResponse<string>?> SetClearanceSchedule(SetClearanceScheduleRequest req, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"{BaseUrl}/api/admin/clearance-schedule");
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(req);
            var response = await _http.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}