using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BitadAPI.Dto
{
    public class DtoUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]{1,}@[a-zA-Z0-9]{1,}\.[a-zA-Z]{1,}$")]
        [DefaultValue("a@a.com")]
        public string Email { get; set; }
        public int CurrentScore { get; set; }
        public DtoWorkshop Workshop { get; set; }
    }
}
