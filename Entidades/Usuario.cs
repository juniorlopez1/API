using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entidades
{
    public class Usuario
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

        [BsonElement(nameof(NombreUsuario))]
        public string NombreUsuario { get; set; }

        [BsonElement(nameof(Contrasena))]
        public string Contrasena { get; set; }

        [BsonElement(nameof(Estado))]
        public bool Estado { get; set; }

        //Otras entidades
        [BsonElement(nameof(Perfil))]
        public Perfil Perfil { get; set; }

        #endregion


        #region Constructor
        public Usuario()
        {
            Id = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            Estado = true;
            Perfil = new Perfil () ;
        }
        #endregion
    }
}
