using System;
namespace BitadAPI.Dto
{
    public class TokenRefreshResponse<T>
    {
        public static TokenRefreshResponse<T> NullResponse(string token) => new TokenRefreshResponse<T> { Body = default, Token = token };
        public T Body { get; set; }
        public string Token { get; set; }
    }
}
