using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Restablecimiento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement(nameof(IdUsuario))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUsuario { get; set; }

        [BsonElement(nameof(Codigo))]
        public string Codigo { get; set; }


    }
}
