using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BitadAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Code { get; set; }
        public string Email { get; set; }
        public int CurrentScore { get; set; }
        public Workshop Workshop { get; set; }
    }
}
