using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BitadAPI.Models;

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
        public string AttendanceCode { get; set; }
        public UserRole Role { get; set; }
        public ShirtSize ShirtSize { get; set; }
        public string WorkshopAttendanceCode { get; set; }
    }
}
