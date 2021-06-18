using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitadAPI.Models
{
    public enum SponsorRank
    {
        Diamond,
        Gold,
        Silver
    }

    public class Sponsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public SponsorRank Rank { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Webpage { get; set; }
    }
}
