using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Perfil
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

        [BsonElement(nameof(Tipo))]
        public string Tipo { get; set; }

        [BsonElement(nameof(Estado))]
        public bool Estado { get; set; }

        #endregion

        #region Constructor
        public Perfil()
        {
            Id = string.Empty;
            Tipo = string.Empty;
            Codigo = string.Empty;
            Estado = true;
        }
        #endregion
    }
}
