using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Adressbook.Interfaces
{
    public interface IPersonInfo
    {
        [JsonIgnore]
        Guid PersonNumber { get; set; }
        [JsonIgnore]
        bool IsVerified { get; set; }

        int Id { get; set; }
        string FirstName { get; set; } 
        string LastName { get; set; } 
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Email { get; set; }
    }
}
