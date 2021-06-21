using System;
namespace BitadAPI.Dto
{
    public class DtoUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int CurrentScore { get; set; }
        public DtoWorkshop Workshop { get; set; }
    }
}
