using System.Text.Json;
using Microsoft.JSInterop;
using Myblazorapp.Models;

namespace Myblazorapp.Services
{
    public class SessionService
    {
        private const string StorageKey = "eventease_user";
        private readonly IJSRuntime _js;
        private UserSession? _current;

        public SessionService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<UserSession?> GetCurrentAsync()
        {
            if (_current != null) return _current;
            try
            {
                var json = await _js.InvokeAsync<string>("sessionStorage.getItem", StorageKey);
                if (string.IsNullOrWhiteSpace(json)) return null;
                _current = JsonSerializer.Deserialize<UserSession>(json);
                return _current;
            }
            catch
            {
                return null;
            }
        }

        public async Task SignInAsync(UserSession user)
        {
            _current = user;
            var json = JsonSerializer.Serialize(user);
            await _js.InvokeVoidAsync("sessionStorage.setItem", StorageKey, json);
        }

        public async Task SignOutAsync()
        {
            _current = null;
            await _js.InvokeVoidAsync("sessionStorage.removeItem", StorageKey);
        }
    }
}
