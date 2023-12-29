using Adressbook.Enums;
using Adressbook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbook.Models.Responses
{


    public class ServiceResult : IServiceResult
    {
        public ServiceStatus Status { get; set; }
        public object Result { get; set; } = null!;
    }
}
