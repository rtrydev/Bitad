using System;
namespace BitadAPI.Dto
{
    public class DtoWorkshop
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParticipantsNumber { get; set; }
        public string Room { get; set; }
        public DtoSpeaker Speaker { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Code { get; set; }
    }
}
