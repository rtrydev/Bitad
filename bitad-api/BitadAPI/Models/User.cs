
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BitadAPI.Models
{
    public enum UserRole
    {
        Guest,
        Admin
    }

    public enum ShirtSize
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL,
        XXXXL
    }
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
        public string ActivationCode { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string ConfirmCode { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string AttendanceCode { get; set; }
        public DateTime? AttendanceCheckDate { get; set; }
        public UserRole Role { get; set; }
        
        public ShirtSize? ShirtSize { get; set; }
    }
}
