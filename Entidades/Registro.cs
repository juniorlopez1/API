using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Registro
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

        [BsonElement(nameof(Ingreso))]
        public DateTime Ingreso { get; set; }

        [BsonElement(nameof(Salida))]
        public DateTime Salida { get; set; }

        //Otras entidades
        [BsonElement(nameof(Aeronave))]
        public Aeronave Aeronave { get; set; }

        [BsonElement(nameof(EstadoVuelo))]
        public EstadoVuelo EstadoVuelo { get; set; }

        [BsonElement(nameof(Observaciones))]
        public Observacion Observaciones { get; set; }
        #endregion



        #region Constructor
        public Registro()
        {
            Id = string.Empty;
            Ingreso = DateTime.MinValue;
            Salida = DateTime.MinValue;
            Aeronave = new Aeronave ();
            EstadoVuelo = new EstadoVuelo();
            Observaciones = new Observacion();
        }
        #endregion
    }
}
