using Newtonsoft.Json;
using OSIsoft.AF.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisEvaluationListener
{
    public class AFTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AFTime);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var time = (AFTime)value;
            writer.WriteValue(time.UtcTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dt = (DateTime)reader.Value;
            return new AFTime(dt);
        }
    }
}
