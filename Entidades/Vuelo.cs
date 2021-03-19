using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Vuelo
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

        [BsonElement(nameof(FechaPartida))]
        public DateTime FechaPartida { get; set; }

        [BsonElement(nameof(FechaLlegada))]
        public DateTime FechaLlegada { get; set; }

        [BsonElement(nameof(TiempoEstimado))]
        public int TiempoEstimado { get; set; }

        [BsonElement(nameof(DestinoPartida))]
        public string DestinoPartida { get; set; }

        [BsonElement(nameof(DestinoFinal))]
        public string DestinoFinal { get; set; }

        [BsonElement(nameof(AsientosOcupados))]
        public int AsientosOcupados { get; set; }

        [BsonElement(nameof(Aeronave))]
        public Aeronave Aeronave { get; set; }

        #endregion
    }
}
