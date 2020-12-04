using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ITunes.UrlShortener.Entities.Entities
{
    public class ShortUrl
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }
        
        [BsonElement("CreateDate")]
        public DateTime CreateDate { get; set; }
        
        [BsonElement("ShortURL")]
        public string ShortURL { get; set; }

        [BsonElement("LongURL")]
        public string LongURL { get; set; }
    }
}