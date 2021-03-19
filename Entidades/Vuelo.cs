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
        //nameof busca fields en C# que coincida con mongoDB
        //no confundir Id de mongo con keys de entidades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


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



        #region Constructor
        public Vuelo ()
        {
            Id = string.Empty;
            Codigo = string.Empty;
            FechaPartida = DateTime.MinValue;
            FechaLlegada = DateTime.MinValue;
            TiempoEstimado = 0;
            DestinoPartida = string.Empty;
            DestinoFinal = string.Empty;
            AsientosOcupados = 0;
            //Aeronave type
        }
        #endregion
    }
}
