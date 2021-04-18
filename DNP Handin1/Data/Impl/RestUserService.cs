using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace DNP_Handin1.Data
{
    public class RestUserService : IUserService
    {
        public async Task<User> ValidateUserAsync(string UserName, string Password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5001/login?username={UserName}&password={Password}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return user;
        }
    }
}