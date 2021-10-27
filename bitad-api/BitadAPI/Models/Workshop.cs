using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitadAPI.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortInfo { get; set; }
        public string ExternalLink { get; set; }
        public ICollection<User> Participants { get; set; }
        public int ParticipantsNumber { get => Participants is not null ? Participants.Count : 0; }
        public string Room { get; set; }
        public Speaker Speaker { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Code { get; set; }
        public int MaxParticipants { get; set; }
    }
}
