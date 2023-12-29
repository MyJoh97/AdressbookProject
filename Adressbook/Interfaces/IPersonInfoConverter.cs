using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Adressbook.Interfaces
{
    public class IPersonInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IPersonInfo));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            var personInfo = new PersonInfo();
            serializer.Populate(jsonObject.CreateReader(), personInfo);
            return personInfo;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}