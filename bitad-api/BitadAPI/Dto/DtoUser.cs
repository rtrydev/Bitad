using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BitadAPI.Models;

namespace BitadAPI.Dto
{
    public class DtoUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CurrentScore { get; set; }
        public DtoWorkshop Workshop { get; set; }
        public string AttendanceCode { get; set; }
        public UserRole Role { get; set; }
        public string RewardCode => AttendanceCode.Substring(0, 4).ToLower();
    }
}
