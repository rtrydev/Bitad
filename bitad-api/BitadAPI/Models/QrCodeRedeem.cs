using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitadAPI.Models
{
    public class QrCodeRedeem
    {
        public int Id { get; set; }
        public QrCode QrCode { get; set; }
        public User User { get; set; }
        public DateTime RedeemTime { get; set; }
    }
}
