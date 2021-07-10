using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GratitudeTextAPI_v1.Models
{
    public class Text
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Text")]
        [JsonProperty("Text")]
        public string TextValue { get; set; }

        //[BsonElement("Created")]
        //[BsonRepresentation(BsonType.DateTime)]
        public string Created { get; set; }
    }
}
