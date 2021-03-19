using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Pista
    {
        #region Propiedades
        //Primero instalar nuggets de mongoDB Driver
        //[BsonId] Usa la llave (key) de mongo
        //Para que se genere automaticamente
        //[BsonElement("Id")] No hace falta en mongoDB
        //nameof busca fields en C# que coincida con mongoDB
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement(nameof(Codigo))]
        public string Codigo { get; set; }

        [BsonElement(nameof(Observaciones))]
        public List<string> Observaciones { get; set; }

        //[BsonElement(nameof(PistaEstado))]
        //public PistaEstado PistaEstado { get; set; }
        #endregion
    }
}
