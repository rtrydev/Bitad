using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BitadAPI.Common
{
    public class CodeGenerator
    {
        public string GenerateWorkshopAttendanceCode()
        {
            var rnd = new Random();
            var codeBuilder = new StringBuilder();
            for(int i=0; i < 5; i++)
            {
                codeBuilder.Append((char)rnd.Next('A', 'Z'));
            }
            return codeBuilder.ToString();
        }

        public string GenerateRandomCode()
        {
            Guid g = Guid.NewGuid();
            string stringCode = Convert.ToBase64String(g.ToByteArray());
            return stringCode.Replace("=", "").
                Replace("/", "").
                Replace("+", "");
        }

        
    }
}