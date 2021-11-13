using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitadAPI.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Degree { get; set; }
        public string Contact { get; set; }
        public bool IsPublic { get; set; }
        public string StaffRole { get; set; }

    }
}
