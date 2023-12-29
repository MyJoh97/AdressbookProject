using Adressbook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Adressbook.Models
{
    public class PersonInfo : IPersonInfo
    {

        public int Id { get; set; } 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;

        [JsonIgnore]
        public Guid PersonNumber { get; set; }
        [JsonIgnore]
        public bool IsVerified { get; set; }
    }
}
