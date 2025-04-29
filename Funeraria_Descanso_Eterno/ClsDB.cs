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
                    //creacion de tablas termanda hasta el momento
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

        }
    }
}