using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitadAPI.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Speaker Speaker { get; set; }

    }
}
