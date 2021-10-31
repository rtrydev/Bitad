using System;
namespace BitadAPI.Dto
{
    public class TokenRefreshResponse<T>
    {
        public static TokenRefreshResponse<T> NullResponse(string token, int code) => new TokenRefreshResponse<T> { Body = default, Token = token, Code = code};
        public T Body { get; set; }
        public string Token { get; set; }
        public int Code { get; set; }
    }

    public class TokenRefreshResponse
    {
        public string Token { get; set; }
        public int Code { get; set; }
    }
}
