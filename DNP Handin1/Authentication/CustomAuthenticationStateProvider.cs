using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using DNP_Handin1.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models;

namespace DNP_Handin1.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime JsRuntime;
        private readonly IUserService UserService;

        private User cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService)
        {
            JsRuntime = jsRuntime;
            UserService = userService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await JsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    User tmp = JsonSerializer.Deserialize<User>(userAsJson);
                    ValidateLogin(tmp.UserName, tmp.Password);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string UserName, string Password)
        {
            Console.WriteLine("Validate log in");
            if (string.IsNullOrEmpty(UserName))
            {
                throw new Exception("Enter username");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Enter password");
            }

            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                User user = await UserService.ValidateUserAsync(UserName, Password);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                JsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
            }
            catch (Exception e)
            {
                throw new Exception("Identity claim failed");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            JsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("Role", user.Role));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}