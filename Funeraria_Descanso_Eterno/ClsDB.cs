using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;

namespace Funeraria_Descanso_Eterno
{
    //espacio para clases de la db
    public class ConexionSQLite  //obtiene la conexion una vez y la devuelve en caso de ya estar creada
    {
        private static ConexionSQLite instancia;
        private SQLiteConnection conexion;

        private ConexionSQLite()
        {
            string cadenaConexion = "Data Source=DBFunebre.db;Version=3;Compress=True;";
            conexion = new SQLiteConnection(cadenaConexion);
            conexion.Open();
            MessageBox.Show("Conectado a la base de datos");
        }

        public static ConexionSQLite Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ConexionSQLite();

                MessageBox.Show("Ya existe una instancia de la base de datos");
                return instancia;
            }
        }

        public SQLiteConnection ObtenerConexion()
        {
            MessageBox.Show("Conectando a la base de datos return");
            return conexion;
        }
    }


    public class AddTables
    {
        public void CreateTable()
        {
            try
            {

                SQLiteConnection conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion(); ;
                SQLiteCommand cmd_sqlite;
                SQLiteDataReader datareader_sqlite;

                conexion_sqlite.Open();

                /////creo la tabla -------------------------------------------------------------------
                cmd_sqlite = conexion_sqlite.CreateCommand();
                cmd_sqlite.CommandText = "CREATE TABLE Users(ID_User integer primary key, Nombre varchar(20), usuario varchar(25), password varchar(25));";
                cmd_sqlite.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}