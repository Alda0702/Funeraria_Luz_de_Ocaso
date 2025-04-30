using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Funeraria_Descanso_Eterno
{
    public class ConexionSQLite
    {
        private static ConexionSQLite instancia;
        private SQLiteConnection conexion;
        private bool conexionAbierta = false;


        private ConexionSQLite() { }

        public static ConexionSQLite Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ConexionSQLite();
                return instancia;
            }
        }

        public SQLiteConnection ObtenerConexion()
        {
            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                string cadenaConexion = "Data Source=DBFunebre.db;Version=3;Compress=True;";
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open();
                conexionAbierta = true;
            }
            return conexion;
        }
        public void CerrarConexion()
        {
            if (conexionAbierta && conexion != null)
            {
                conexion.Close();
                conexionAbierta = false;
            }
        }
    }

    public class servicios
    {
        SQLiteConnection conexion_sqlite;
        SQLiteCommand cmd_sqlite;

        public void InsertarCliente(string Nombre, string Descripcion, string Categoria, int DuracioEst, int Precio)
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
    }

    public class Inventario
    {
        SQLiteConnection conexion_sqlite;
        SQLiteCommand cmd_sqlite;
        public void InsertarProducto(string Nombre, string Descripcion, string Categoria, int Stock, int Precio)
        {
            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();
                cmd_sqlite.CommandText = $"INSERT INTO Inventario (Nombre_P, Descripcion_P, Categoria_P, Stock_P, Precio_P) " +
                                         $"VALUES ('{Nombre}', '{Descripcion}', '{Categoria}', {Stock}, {Precio})";
                cmd_sqlite.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
            }
        }
        public void MostrarInventario(DataGridView dgv)
        {
            SQLiteDataReader reader = null;
            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();
                cmd_sqlite.CommandText = "SELECT * FROM Inventario";

                reader = cmd_sqlite.ExecuteReader();
                while (reader.Read())
                {
                    dgv.Rows.Add(reader["Codigo_Prod"].ToString(),
                                 reader["Nombre_P"].ToString(),
                                 reader["Descripcion_P"].ToString(),
                                 reader["Categoria_P"].ToString(),
                                 reader["Stock_P"].ToString(),
                                 reader["Precio_P"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el inventario: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

                ConexionSQLite.Instancia.CerrarConexion();
            }
        }
        public void BuscarPorCodigo(DataGridView dgv, string codigo)
        {
            SQLiteDataReader reader = null;
            try
            {
                dgv.Rows.Clear();
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();
                cmd_sqlite.CommandText = $"SELECT * FROM Inventario WHERE Codigo_Prod LIKE '%{codigo}%'";
                reader = cmd_sqlite.ExecuteReader();
                while (reader.Read())
                {
                    dgv.Rows.Add(reader["Codigo_Prod"].ToString(),
                                 reader["Nombre_P"].ToString(),
                                 reader["Descripcion_P"].ToString(),
                                 reader["Categoria_P"].ToString(),
                                 reader["Stock_P"].ToString(),
                                 reader["Precio_P"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

                ConexionSQLite.Instancia.CerrarConexion();
            }
        }
        public bool BuscarProducto(string textoBusqueda, out string codigo, out string nombre)
        {
            SQLiteDataReader reader = null;
            codigo = "";
            nombre = "";

            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();
                cmd_sqlite.CommandText = $"SELECT * FROM Inventario WHERE Codigo_Prod LIKE '%{textoBusqueda}%' OR Nombre_P LIKE '%{textoBusqueda}%'";
                reader = cmd_sqlite.ExecuteReader();

                if (reader.Read())
                {
                    codigo = reader["Codigo_Prod"].ToString();
                    nombre = reader["Nombre_P"].ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

                ConexionSQLite.Instancia.CerrarConexion();
            }

            return false;
        }
        public bool EliminarProductoPorCodigo(string codigo)
        {
            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                // Verificar si existe
                cmd_sqlite.CommandText = $"SELECT COUNT(*) FROM Inventario WHERE Codigo_Prod = '{codigo}'";
                long count = Convert.ToInt64(cmd_sqlite.ExecuteScalar());

                if (count == 0)
                {
                    MessageBox.Show("El producto con el código " + codigo + " no existe en la base de datos.");
                    return false;
                }

                // Eliminar
                cmd_sqlite.CommandText = $"DELETE FROM Inventario WHERE Codigo_Prod = '{codigo}'";
                int filasAfectadas = cmd_sqlite.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Producto eliminado correctamente.");
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                return false;
            }
            finally
            {
                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

                ConexionSQLite.Instancia.CerrarConexion();
            }
        }
    }
}

