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
        //[BsonElement("Id")] No hace falta en mongoDB
        //nameof busca fields en C# que coincida con mongoDB
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement(nameof(Codigo))]
        public string Codigo { get; set; }

        [BsonElement(nameof(Descripcion))]
        public string Descripcion { get; set; }

        [BsonElement(nameof(Estado))]
        public string Estado { get; set; }

        #endregion

        #region Constructor 
        public Perfil ()
        {
            Id = String.Empty;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            Estado = string.Empty;
        }
        #endregion
    }
}
