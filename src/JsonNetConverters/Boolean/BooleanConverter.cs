using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonNetConverters.Boolean
{
    public class BooleanConverter : DateTimeConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool) || objectType == typeof(bool?);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((bool)value ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int convertedValue;
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.String:
                    if (!int.TryParse(reader.Value.ToString(), out convertedValue))
                        throw new ArgumentException($"{reader.Value} isn't a number");
                    break;
                default:
                    throw new ArgumentException(
                        $"Unexpected token. Integer or String was expected, got {reader.TokenType}");
            }

            if (convertedValue != 0 && convertedValue != 1)
                throw new ArgumentException("Input value should be 1 or 0");

            return convertedValue == 1;
        }
    }
}
