using System.Net.Http.Json;
using SchoolClearanceWeb.Model;

namespace SchoolClearanceWeb.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "http://localhost:5269";

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<object>> LoginStudent(StudentLoginRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{BaseUrl}/api/studentauth/login", request);
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<object>>();
                return result ?? new ServiceResponse<object> { Status = 0, Message = "No response from server." };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object> { Status = 0, Message = $"Connection error: {ex.Message}" };
            }
        }

        public async Task<ServiceResponse<string>> RegisterStudent(StudentRegisterRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{BaseUrl}/api/studentauth/register", request);
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
                return result ?? new ServiceResponse<string> { Status = 0, Message = "No response from server." };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string> { Status = 0, Message = $"Connection error: {ex.Message}" };
            }
        }
    }
}
