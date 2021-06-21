using System;
namespace BitadAPI.Dto
{
    public class TokenRefreshResponse<T>
    {
        public T Body { get; set; }
        public string Token { get; set; }
    }
}
