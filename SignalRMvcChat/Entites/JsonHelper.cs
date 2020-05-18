using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;

namespace SignalRMvcChat.Entites
{
    public static class JsonHelper
    {
        public static JObject ToJObject(this string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JObject.Parse(json.Replace("&nbsp;", ""));
            }
            return JObject.Parse("{}");
        }

        public static string ToJson(this object obj, string datetimeformats = null)
        {
            IList<JsonConverter> converts = new List<JsonConverter>()
            {
                new IsoDateTimeConverter
                {
                    DateTimeFormat = string.IsNullOrEmpty(datetimeformats) ? "yyyy-MM-dd HH:mm" : datetimeformats
                }
            };
            var settings = new JsonSerializerSettings()
            {
                Converters = converts
            };
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static object ToObject(this string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject(json);
            }
            return null;
        }

        public static List<T> ToList<T>(this string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            return null;
        }

        public static T ToModel<T>(this string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }

        public static DataTable ToDateTable(this string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<DataTable>(json);
            }
            return null;
        }
    }
}