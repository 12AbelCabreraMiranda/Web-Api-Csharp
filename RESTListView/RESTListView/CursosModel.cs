﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using RESTListView;
//Librerias HttpClient y Newtonsoft
//    var cursosModel = CursosModel.FromJson(jsonString);

namespace RESTListView
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CursosModel
    {
        [JsonProperty("cursos")]
        public Curso[] Cursos { get; set; }
    }

    public partial class Curso
    {
        [JsonProperty("idCurso")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long IdCurso { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("imagen")]
        public string Imagen { get; set; }

        [JsonProperty("duracion")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Duracion { get; set; }
    }

    public partial class CursosModel
    {
        public static CursosModel FromJson(string json) => JsonConvert.DeserializeObject<CursosModel>(json, RESTListView.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CursosModel self) => JsonConvert.SerializeObject(self, RESTListView.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
