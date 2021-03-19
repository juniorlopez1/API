using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entidades
{
    public class Aeronave
    {
        #region Propiedades
        //Primero instalar nuggets de mongoDB Driver
        //[BsonId] Usa la llave (key) de mongo
        //Para que se genere automaticamente
        //[BsonElement("Id")] No hace falta en mongoDB
        //nameof busca fields en C# que coincida con mongoDB
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement(nameof(Codigo))]
        public string Codigo { get; set; }

        [BsonElement(nameof(Capacidad))]
        public int Capacidad { get; set; }

        [BsonElement(nameof(Estado))]
        public string Estado { get; set; }

        #endregion


        #region Constructor
        public Aeronave ()
        {
            //ID = predefinido por mongoDB
            Codigo = string.Empty;
            Capacidad = 0;
            Estado = string.Empty;
        }
        #endregion
    }
}
