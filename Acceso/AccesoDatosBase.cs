using Entidades;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Acceso
{
    public abstract class AccesoDatosBase
    {
        #region Propiedades
        protected MongoClient instancia;
        protected IMongoDatabase basedatos;

        protected readonly string cadenaConexion;
        protected readonly string nombreBD;
        #endregion

        #region Constructor

        public AccesoDatosBase(string cadenaConexion, string nombreBD)
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
        protected bool GetConexion(string nombreBD)
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

        protected void Crear<T>(string nombreColeccion, T entidad)
        {
            try
            {
                GetConexion(nombreBD);
                var coleccion = basedatos.GetCollection<T>(nombreColeccion);
                coleccion.InsertOne(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected List<T> Leer<T>(string nombreColeccion)
        {
            var resultado = new List<T>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<T>(nombreColeccion);
                resultado = coleccion.Find(d => true).ToList() ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        protected void Actualizar<T>(string nombreColeccion, FilterDefinition<T> filtro, T entidad)
        {
            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<T>(nombreColeccion);
                coleccion.ReplaceOne(filtro, entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Eliminar<T>(string nombreColeccion, Expression<Func<T, bool>> filtro)
        {
            try
            {
                GetConexion(this.nombreBD);
                basedatos.GetCollection<T>(nombreColeccion).DeleteOne(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected List<T> Buscar<T>(string nombreColeccion, Expression<Func<T, bool>> filtro)
        {
            List<T> resultado;
            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<T>(nombreColeccion);
                resultado = coleccion.AsQueryable().Where(filtro).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
    }

    
}
