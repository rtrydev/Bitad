using System;
namespace BitadAPI.Dto
{
    public enum SponsorRank
    {
        Diamond,
        Gold,
        Silver
    }

    public class DtoSponsor
    {
        public SponsorRank Rank { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Webpage { get; set; }
    }
}
