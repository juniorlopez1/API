using Entidades;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

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
                resultado = coleccion.Find(d => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        protected void Actualizar<T>(string nombreColeccion, Func<T, bool> filtro, T entidad)
        {
            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<T>(nombreColeccion);
                basedatos.GetCollection<T>(nombreColeccion).ReplaceOne(u => filtro(u), entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Eliminar<T>(string nombreColeccion, Func<T, bool> filtro)
        {
            try
            {
                GetConexion(this.nombreBD);
                basedatos.GetCollection<T>(nombreColeccion).DeleteOne(u => filtro(u));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected T Buscar<T>(string nombreColeccion, Func<T, bool> filtro)
        {
            var resultado = default(T);

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<T>(nombreColeccion);
                resultado = coleccion.Find(u => filtro(u)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
    }

    public class AccesoDatos : AccesoDatosBase
    {
        public AccesoDatos(string cadenaConexion, string nombreBD)
            :base(cadenaConexion, nombreBD)
        {

        }

        //----------------------Aeronave ----------------------

        #region CREATE
        public void CrearAeronaves(Aeronave aeronave)
        {
            Crear<Aeronave>(nameof(Aeronave), aeronave);
        }
        #endregion

        #region READ
        public List<Aeronave> LeerAeronaves()
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
        public void ActualizarAeronaves(Aeronave aeronave)
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
        public void EliminarAeronaves(string Codigo)
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
        public Aeronave BuscarAeronaves(string Codigo)
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
        public void CrearPerfiles(Perfil perfil)
        {
            try
            {
                GetConexion(nombreBD);
                var coleccion = basedatos.GetCollection<Perfil>("Perfil");
                coleccion.InsertOne(perfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region READ
        public List<Perfil> LeerPerfiles()
        {
            var resultado = new List<Perfil>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Perfil>("Perfil");
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
        public void ActualizarPerfiles(Perfil perfil)
        {
            var resultado = new List<Perfil>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Perfil>("Perfil");
                basedatos.GetCollection<Perfil>("Perfil").ReplaceOne(u => u.Codigo == perfil.Codigo, perfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE
        public void EliminarPerfiles(string Codigo)
        {

            try
            {
                GetConexion(this.nombreBD);
                basedatos.GetCollection<Perfil>("Perfil").DeleteOne(u => u.Codigo == Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SEARCH
        public Perfil BuscarPerfiles(string Codigo)
        {
            var resultado = default(Perfil);

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Perfil>("Perfil");
                resultado = coleccion.Find(u => u.Codigo == Codigo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        #endregion

        //---------------------- Usuario ----------------------

        #region CREATE
        public void CrearUsuarios(Usuario usuario)
        {
            try
            {
                GetConexion(nombreBD);
                var coleccion = basedatos.GetCollection<Usuario>("Usuario");
                coleccion.InsertOne(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region READ
        public List<Usuario> LeerUsuarios()
        {
            var resultado = new List<Usuario>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Usuario>("Usuario");
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
        public void ActualizarUsuarios(Usuario usuario)
        {
            var resultado = new List<Usuario>();

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Usuario>("Usuario");
                basedatos.GetCollection<Usuario>("Usuario").ReplaceOne(u => u.Id == usuario.Id, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE
        public void EliminarUsuarios(string Id)
        {

            try
            {
                GetConexion(this.nombreBD);
                basedatos.GetCollection<Usuario>("Usuario").DeleteOne(u => u.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SEARCH
        public Usuario BuscarUsuarios(string NombreUsuario)
        {
            var usuario = default(Usuario);

            try
            {
                GetConexion(this.nombreBD);
                var coleccion = basedatos.GetCollection<Usuario>("Usuario");
                usuario = coleccion.Find(u => u.NombreUsuario == NombreUsuario).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuario;
        }
        #endregion

    }
}
