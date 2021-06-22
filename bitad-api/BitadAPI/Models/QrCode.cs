using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitadAPI.Models
{
    public class QrCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Points { get; set; }
        public DateTime ActivationTime { get; set; }
        public DateTime DeactivationTime { get; set; }
    }
}
