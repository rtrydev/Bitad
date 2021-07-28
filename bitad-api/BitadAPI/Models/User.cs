
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BitadAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int CurrentScore { get; set; }
        public string CurrentJwt { get; set; }
        public Workshop Workshop { get; set; }
        public string PasswordSalt { get; set; }
        
        public string CreationIp { get; set; }
    }
}
