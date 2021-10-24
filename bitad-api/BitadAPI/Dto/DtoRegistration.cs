using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BitadAPI.Models;

namespace BitadAPI.Dto
{
    public class DtoRegistration
    {
        [RegularExpression(@"^[a-zA-Z0-9\.-_]{1,}@[a-zA-Z0-9]{1,}\.[a-zA-Z]{1,}$")]
        [DefaultValue("a@a.com")]
        public string Email { get; set; }
        [MaxLength(24)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,24}")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,24}")]
        public string LastName { get; set; }
        [MaxLength(24)]
        [MinLength(4)]
        public string Username { get; set; }
        [MaxLength(50)]
        [MinLength(6)]
        public string Password { get; set; }
        public string WorkshopCode { get; set; }
        public ShirtSize ShirtSize { get; set; }
    }
}
