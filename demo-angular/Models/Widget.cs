using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Widget
    {
        [Key]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
