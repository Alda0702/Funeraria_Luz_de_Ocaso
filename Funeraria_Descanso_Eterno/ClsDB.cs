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

        // Bandera que indica si la conexión está abierta
        private bool conexionAbierta = false;

        // Constructor privado para que nadie pueda crear instancias directamente
        private ConexionSQLite() { }

        // Propiedad pública para obtener la instancia única de la clase
        public static ConexionSQLite Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ConexionSQLite();
                return instancia;
            }
        }

        // Método para obtener una conexión abierta a la base de datos
        public SQLiteConnection ObtenerConexion()
        {
            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                // Cadena de conexión a la base de datos SQLite
                string cadenaConexion = "Data Source=DBFunebre.db;Version=3;Compress=True;";

                // Crear nueva conexión
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open(); // Abrir la conexión

                // Marcar que la conexión está abierta
                conexionAbierta = true;
            }
            return conexion;  // Devolver la conexión abierta
        }

        // Método para cerrar la conexión abierta
        public void CerrarConexion()
        {
            if (conexionAbierta && conexion != null)
            {
                conexion.Close(); // Cierra la conexión
                conexionAbierta = false; // Marca que ya no está abierta
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
            // Declarar el lector de datos para recorrer los resultados de la base de datos
            SQLiteDataReader reader = null;
            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                    // Establecer la instrucción SQL para obtener todos los registros de la tabla Inventario
                cmd_sqlite.CommandText = "SELECT * FROM Inventario";

                // Ejecutar la consulta y obtener un lector con los resultados
                reader = cmd_sqlite.ExecuteReader();

                // Leer fila por fila y agregar cada producto al DataGridView
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

                // Cerrar el lector si está abierto
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                // Liberar el recurso del comando
                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

                // Cerrar la conexión a la base de datos
                ConexionSQLite.Instancia.CerrarConexion();
            }
        }
        public void BuscarPorCodigo(DataGridView dgv, string codigo)
        {
            // Declarar el lector para recorrer los resultados de la consulta
            SQLiteDataReader reader = null;


            try
            {
                // Limpiar las filas existentes del DataGridView antes de mostrar los nuevos resultados 
                dgv.Rows.Clear();

                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                // Establecer y ejecutar la consulta para buscar productos cuyo Código contenga el texto ingresado
                cmd_sqlite.CommandText = $"SELECT * FROM Inventario WHERE Codigo_Prod LIKE '%{codigo}%'";
                reader = cmd_sqlite.ExecuteReader();

                // Leer todos los registros encontrados y agregarlos al DataGridView
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
                // Cerrar el lector si está abierto
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                // Liberar el recurso del comando
                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

                // Cerrar la conexión a la base de datos
                ConexionSQLite.Instancia.CerrarConexion();
            }
        }
        public bool BuscarProducto(string textoBusqueda, out string codigo, out string nombre)
        {
            // Declarar el lector de datos
            SQLiteDataReader reader = null;

            // Inicializar los valores de salida
            codigo = "";
            nombre = "";

            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                // Establecer la consulta SQL para buscar productos cuyo código o nombre coincida parcialmente
                cmd_sqlite.CommandText = $"SELECT * FROM Inventario WHERE Codigo_Prod LIKE '%{textoBusqueda}%' OR Nombre_P LIKE '%{textoBusqueda}%'";
                // Ejecutar la consulta y obtener el lector de resultados
                reader = cmd_sqlite.ExecuteReader();

                // Si se encuentra al menos un registro...
                if (reader.Read())
                {
                    // Asignar los valores encontrados a las variables de salida
                    codigo = reader["Codigo_Prod"].ToString();
                    nombre = reader["Nombre_P"].ToString();

                    // Retornar true indicando que se encontró un producto
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message);
            }
            finally
            {
                // Cerrar el lector si está abierto
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                // Liberar recursos del comando
                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

                // Cerrar la conexión a la base de datos
                ConexionSQLite.Instancia.CerrarConexion();
            }

            // Si no se encontró ningún producto, devolver false
            return false;
        }
        public bool EliminarProductoPorCodigo(string codigo)
        {
            try
            {
                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();

                // Verificar si el producto existe en la base de datos con ese código
                cmd_sqlite.CommandText = $"SELECT COUNT(*) FROM Inventario WHERE Codigo_Prod = '{codigo}'";

                // Ejecutar la consulta y obtener la cantidad de coincidencias
                long count = Convert.ToInt64(cmd_sqlite.ExecuteScalar());

                // Si no existe ningún producto con ese código, mostrar un mensaje y salir
                if (count == 0)
                {
                    MessageBox.Show("El producto con el código " + codigo + " no existe en la base de datos.");
                    return false;
                }

                // Si existe, proceder a eliminarlo
                cmd_sqlite.CommandText = $"DELETE FROM Inventario WHERE Codigo_Prod = '{codigo}'";
                // Ejecutar el comando DELETE
                int filasAfectadas = cmd_sqlite.ExecuteNonQuery();

                // Verificar si realmente se eliminó (si se afectó al menos una fila)
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Producto eliminado correctamente.");
                    return true;
                }
                else
                {
                    // Por si algo salió mal y no se eliminó nada
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
            // Liberar recursos aunque haya éxito o error
            // Liberar el comando
                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();

            // Cerrar la conexión a la base de datos
            ConexionSQLite.Instancia.CerrarConexion();
            }
        }
    }
}

