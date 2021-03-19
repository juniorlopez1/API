using Entidades;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Acceso
{
    public class AccesoDatos
    {
        #region Propiedades
        private MongoClient instancia;
        private IMongoDatabase basedatos;

        private readonly string cadenaConexion;
        private readonly string nombreBD;
        #endregion

        #region Constructor

        public AccesoDatos(string cadenaConexion, string nombreBD)
        {
            try
            {
                this.cadenaConexion = cadenaConexion;
                this.nombreBD = nombreBD;
                GetConexion(nombreBD);
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                instancia = instancia != null ? null : instancia;
                basedatos = basedatos != null ? null : basedatos;
            }
        }
        #endregion

        #region GetConexion
        private bool GetConexion(string nombreBD)
        {
            bool ConexionCorrecta = false;

            try
            {
                if (nombreBD.Length > 0)
                {
                    //Crea instancia de mongodb
                    instancia = new MongoClient(cadenaConexion);

                    //Prueba de conexión a BD
                    basedatos = instancia.GetDatabase(nombreBD);

                    //verifica conexion positiva
                    ConexionCorrecta = basedatos.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
                }
            }
            catch (MongoException exM)
            {
                //excepciones de mongo
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ConexionCorrecta;
        }
        #endregion


        //----------------------Aeronave ----------------------

        #region CREATE
        public void CrearAeronaves (Aeronave aeronave)
        {
            try
            {
                GetConexion(nombreBD);
                var coleccion = basedatos.GetCollection<Aeronave>("Aeronave");
                coleccion.InsertOne(aeronave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region READ
        public List<Aeronave> LeerAeronaves ()
        {
            var resultado = new List<Aeronave>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Aeronave>("Aeronave");
                resultado = coleccion.Find(d => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        #endregion

        #region UPDATE
        public void ActualizarAeronaves (Aeronave aeronave)
        {
            var resultado = new List<Aeronave>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Aeronave>("Aeronave");
                basedatos.GetCollection<Aeronave>("Aeronave").ReplaceOne(u => u.Codigo == aeronave.Codigo, aeronave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE
        public void EliminarAeronaves (string Codigo)
        {

            try
            {
                GetConexion(this.nombreBD);
                basedatos.GetCollection<Aeronave>("Aeronave").DeleteOne(u => u.Codigo == Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region SEARCH
        public Aeronave BuscarAeronaves (string Codigo)
        {
            var resultado = default(Aeronave);

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Aeronave>("Aeronave");
                resultado = coleccion.Find(u => u.Codigo == Codigo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        #endregion



        //---------------------- Perfil ----------------------

        #region CREATE
        public void CrearPerfiles (Pista perfil)
        {
            try
            {
                GetConexion(nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Perfil");
                coleccion.InsertOne(perfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region READ
        public List<Pista> LeerPerfiles()
        {
            var resultado = new List<Pista>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Perfil");
                resultado = coleccion.Find(d => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        #endregion

        #region UPDATE
        public void ActualizarPerfiles (Pista perfil)
        {
            var resultado = new List<Pista>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Perfil");
                basedatos.GetCollection<Pista>("Perfil").ReplaceOne(u => u.Codigo == perfil.Codigo, perfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE
        public void EliminarPerfiles (string Codigo)
        {

            try
            {
                GetConexion(this.nombreBD);
                basedatos.GetCollection<Aeronave>("Perfil").DeleteOne(u => u.Codigo == Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SEARCH
        public Pista BuscarPerfiles (string Codigo)
        {
            var resultado = default(Pista);

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Perfil");
                resultado = coleccion.Find(u => u.Codigo == Codigo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        #endregion





        //---------------------- Pista ----------------------

        #region CREATE
        public void CrearPistas (Pista pista)
        {
            try
            {
                GetConexion(nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Pista");
                coleccion.InsertOne(pista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region READ
        public List<Pista> LeerPistas ()
        {
            var resultado = new List<Pista>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Pista");
                resultado = coleccion.Find(d => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        #endregion

        #region UPDATE
        public void ActualizarPistas (Pista pista)
        {
            var resultado = new List<Pista>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Pista");
                basedatos.GetCollection<Pista>("Pista").ReplaceOne(u => u.Codigo == pista.Codigo,  pista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE
        public void EliminarPistas (string Codigo)
        {

            try
            {
                GetConexion(this.nombreBD);
                basedatos.GetCollection<Aeronave>("Pista").DeleteOne(u => u.Codigo == Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SEARCH
        public Pista BuscarPistas (string Codigo)
        {
            var resultado = default(Pista);

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Pista>("Pista");
                resultado = coleccion.Find(u => u.Codigo == Codigo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        #endregion


    }
}
