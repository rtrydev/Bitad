using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitadAPI.Models
{
    public class Workshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParticipantsNumber { get; set; }
        public string Room { get; set; }
        public Speaker Speaker { get; set; }
        public DateTime Start { get; set; }
        public string Code { get; set; }
    }
}
