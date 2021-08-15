using System;
using BitadAPI.Models;

namespace BitadAPI.Dto
{
    public class DtoRegistrationResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DtoWorkshop Workshop { get; set; }
        public ShirtSize ShirtSize { get; set; }

    }
}
