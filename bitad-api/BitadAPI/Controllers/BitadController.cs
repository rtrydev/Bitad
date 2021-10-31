using System;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    public abstract class BitadController : Controller
    {
        protected async Task<ActionResult<TResult>> MakeAuthorizedServiceCall<TResult>(Func<int, Task<TokenRefreshResponse<TResult>>> serviceCall, IJwtService jwtService)
        {
            var authorizationResult = await GetAuthorizationResult(jwtService);
            if (authorizationResult.GetType() == typeof(UnauthorizedResult)) return Unauthorized();
            var result = await serviceCall(authorizationResult.Value);
            return FormResult(result);
        }
        
        protected async Task<ActionResult<TResult>> MakeAuthorizedServiceCall<T, TResult>(T arg1, Func<int, T, Task<TokenRefreshResponse<TResult>>> serviceCall, IJwtService jwtService)
        {
            var authorizationResult = await GetAuthorizationResult(jwtService);
            if (authorizationResult.GetType() == typeof(UnauthorizedResult)) return Unauthorized();
            var result = await serviceCall(authorizationResult.Value, arg1);
            return FormResult(result);
        }
        
        protected async Task<ActionResult<TResult>> MakeAuthorizedServiceCall<T1, T2, TResult>(T1 arg1, T2 arg2, Func<int, T1, T2, Task<TokenRefreshResponse<TResult>>> serviceCall, IJwtService jwtService)
        {
            var authorizationResult = await GetAuthorizationResult(jwtService);
            if (authorizationResult.GetType() == typeof(UnauthorizedResult)) return Unauthorized();
            var result = await serviceCall(authorizationResult.Value, arg1, arg2);
            return FormResult(result);
        }
        
        protected async Task<ActionResult> MakeAuthorizedServiceCall(Func<int, Task<TokenRefreshResponse>> serviceCall, IJwtService jwtService)
        {
            var authorizationResult = await GetAuthorizationResult(jwtService);
            if (authorizationResult.GetType() == typeof(UnauthorizedResult)) return Unauthorized();
            var result = await serviceCall(authorizationResult.Value);
            return FormResult(result);
        }

        private async Task<ActionResult<int>> GetAuthorizationResult(IJwtService jwtService)
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }

            return Ok(id);
        }

        private ActionResult<T> FormResult<T>(TokenRefreshResponse<T> result)
        {
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Code == 403) return Forbid();
            if (result.Code == 404) return NotFound();
            return Ok(result.Body);
        }
        
        private ActionResult FormResult(TokenRefreshResponse result)
        {
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            if (result.Code == 403) return Forbid();
            if (result.Code == 404) return NotFound();
            return Ok();
        }
        
    }
}