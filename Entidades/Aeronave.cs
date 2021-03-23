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
        //nameof busca fields en C# que coincida con mongoDB
        //no confundir Id de mongo con keys de entidades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement(nameof(Codigo))]
        public string Codigo { get; set; }

        [BsonElement(nameof(Capacidad))]
        public int Capacidad { get; set; }

        [BsonElement(nameof(Estado))]
        public bool Estado { get; set; }

        //!
        [BsonElement(nameof(Observacion))]
        public bool Observacion { get; set; }

        //!
        [BsonElement(nameof(Desperfecto))]
        public bool Desperfecto { get; set; }


        [BsonElement(nameof(AeronaveTipo))]
        public AeronaveTipo AeronaveTipo { get; set; }

        #endregion


        #region Constructor
        public Aeronave()
        {
            Id = string.Empty;
            Codigo = string.Empty;
            Estado = true;
            Capacidad = 0;
            AeronaveTipo = new AeronaveTipo();
            Observacion = true;
            Desperfecto = true;
        }
        #endregion
    }
}
