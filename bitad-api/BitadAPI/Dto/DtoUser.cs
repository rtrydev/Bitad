using System;
namespace BitadAPI.Dto
{
    public class DtoUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int CurrentScore { get; set; }
        public DtoWorkshop Workshop { get; set; }
    }
}
