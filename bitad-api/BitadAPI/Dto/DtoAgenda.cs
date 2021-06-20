using System;
namespace BitadAPI.Dto
{
    public class DtoAgenda
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DtoSpeaker Speaker { get; set; }
    }
}
