using System;
namespace BitadAPI.Dto
{
    public class DtoRegistration
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string WorkshopCode { get; set; }
    }
}
