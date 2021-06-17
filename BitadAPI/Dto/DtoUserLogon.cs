using System;
using BitadAPI.Models;

namespace BitadAPI.Dto
{
    public class DtoUserLogon
    {
        public DtoUser User { get; set; }
        public string Token { get; set; }
    }
}
