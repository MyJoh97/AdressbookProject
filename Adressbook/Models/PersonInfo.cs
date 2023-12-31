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
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; } = null!;

        [JsonPropertyName("LastName")]
        public string LastName { get; set; } = null!;

        [JsonPropertyName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("Email")]
        public string Email { get; set; } = null!;

        [JsonIgnore]
        public Guid PersonNumber { get; set; }

        [JsonIgnore]
        public bool IsVerified { get; set; }
    }

}
