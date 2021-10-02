using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modern.Object.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpireDays { get; set; }
    }
}
