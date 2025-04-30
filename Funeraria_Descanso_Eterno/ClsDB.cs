using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Funeraria_Descanso_Eterno
{
    public class ConexionSQLite
    {
        private static ConexionSQLite instancia;
        private SQLiteConnection conexion;

        private ConexionSQLite()
        {
            try
            {
                string cadenaConexion = "Data Source=DBFunebre.db;Version=3;Compress=True;";
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open();
                // MessageBox.Show("Conectado a la base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        public static ConexionSQLite Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ConexionSQLite();
                }

                return instancia;
            }
        }

        public SQLiteConnection ObtenerConexion()
        {
            return conexion;
        }
    }

    public class servicios
    {
        SQLiteConnection conexion_sqlite;
        SQLiteCommand cmd_sqlite;

        public void InsertarServicios(string Nombre, string Descripcion, string Categoria, int DuracioEst, int Precio)
        {

            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                cmd_sqlite.CommandText = $"INSERT INTO Servicio (Nombre_P, Descripcion_P, Categoria_P, Duracion_estimadaHrs_P, Precio_P)VALUES  ('{Nombre}','{Descripcion}', '{Categoria} ', ' {DuracioEst}' ,  {Precio})";
                cmd_sqlite.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el cliente: " + ex.Message);
            }
        }

       public void mostrardata(DataGridView dgv)
       {
            SQLiteDataReader datareader_sqlite;
            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                cmd_sqlite.CommandText = $"Select * FROM Servicio";
                cmd_sqlite.ExecuteNonQuery();
                datareader_sqlite = cmd_sqlite.ExecuteReader();

                while (datareader_sqlite.Read())
                {
                    dgv.Rows.Add(datareader_sqlite["Codigo_Servicio"].ToString(), datareader_sqlite["Nombre_P"].ToString(), datareader_sqlite["Descripcion_P"].ToString(), datareader_sqlite["Categoria_P"].ToString(), datareader_sqlite["Duracion_estimadaHrs_P"].ToString(), datareader_sqlite["Precio_P"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.Message);
            }

        }


        public void altertable()
        {
            //try
            //{
            //    conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
            //    cmd_sqlite = conexion_sqlite.CreateCommand();

            //    //cmd_sqlite.CommandText = $"ALTER TABLE Cliente ADD COLUMN Cedula_C TEXT;";

            //    cmd_sqlite.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al alterar la tabla: " + ex.Message);
            //}
        }
           
        
    }

}

