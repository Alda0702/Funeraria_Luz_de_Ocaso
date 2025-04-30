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



    public class EmpleadoDB
    {
        SQLiteConnection conexion_sqlite;
        SQLiteCommand cmd_sqlite;
        public void employee()
        {
            try
            {
                SQLiteConnection conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                SQLiteCommand cmd_sqlite = conexion_sqlite.CreateCommand();

                // Activar soporte de claves foráneas
                cmd_sqlite.CommandText = "PRAGMA foreign_keys = ON;";
                cmd_sqlite.ExecuteNonQuery();

                // Crear tabla Empleado
                cmd_sqlite.CommandText = @"
    CREATE TABLE Empleado (
        ID_Empleado INTEGER PRIMARY KEY,
        REF_Rol INTEGER,
        Nombre_E TEXT NOT NULL,
        ApellidoP_E TEXT NOT NULL,
        ApellidoM_E TEXT NOT NULL,
        Cedula_E TEXT UNIQUE,
        Sexo_E TEXT,
        F_Nacimiento_E TEXT,
        Depto_E TEXT,
        Ciudad_E TEXT,
        Direccion_E TEXT,
        Mail_E TEXT NOT NULL,
        Celular_E TEXT NOT NULL,
        Tdoc_E TEXT,
        FOREIGN KEY (REF_Rol) REFERENCES Rol(ID_Rol)
    );";

                cmd_sqlite.ExecuteNonQuery();
                MessageBox.Show("Tabla Empleado creada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la tabla Empleado: " + ex.Message);
            }




        }
        public void insertroles()
        {
            try
            {
                SQLiteConnection conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                SQLiteCommand cmd_sqlite = conexion_sqlite.CreateCommand();

                // Insertar roles únicos
                cmd_sqlite.CommandText = @"
        INSERT INTO Rol (Nombre) VALUES ('Vendedor');
        INSERT INTO Rol (Nombre) VALUES ('Logística');
        INSERT INTO Rol (Nombre) VALUES ('RRHH');
        INSERT INTO Rol (Nombre) VALUES ('Contradator');

    ";
                cmd_sqlite.ExecuteNonQuery();

                MessageBox.Show("Roles insertados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar roles: " + ex.Message);
            }





        }
        public int InsertarEmpleado(ClsEmpleado emp)
        {
            int idEmpleado = -1;

            try
            {
                SQLiteConnection conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                SQLiteCommand cmd_sqlite = conexion_sqlite.CreateCommand();

                cmd_sqlite.CommandText = $@"
            INSERT INTO Empleado 
            (REF_Rol, Nombre_E, ApellidoP_E, ApellidoM_E, Cedula_E, Sexo_E, F_Nacimiento_E,
             Depto_E, Ciudad_E, Direccion_E, Mail_E, Celular_E, Tdoc_E)
            VALUES ('{emp.REF_Rol}', '{emp.Nombre_E}', '{emp.ApellidoP_E}', '{emp.ApellidoM_E}', 
                    '{emp.Cedula_E}', '{emp.Sexo_E}', '{emp.F_Nacimiento_E}', 
                    '{emp.Depto_E}', '{emp.Ciudad_E}', '{emp.Direccion_E}', 
                    '{emp.Mail_E}', '{emp.Celular_E}', '{emp.Tdoc_E}');";

                cmd_sqlite.ExecuteNonQuery();

                // Obtener el ID recién insertado
                cmd_sqlite.CommandText = "SELECT last_insert_rowid();";
                idEmpleado = Convert.ToInt32(cmd_sqlite.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return idEmpleado;
        }
        public void Mostrarempleado(DataGridView dgv)
        {
            SQLiteDataReader reader = null;
            try
            {
                dgv.Rows.Clear(); // Limpiar filas anteriores si es necesario

                conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                cmd_sqlite = conexion_sqlite.CreateCommand();
                cmd_sqlite.CommandText = "SELECT * FROM Empleado";

                reader = cmd_sqlite.ExecuteReader();
                while (reader.Read())
                {
                    dgv.Rows.Add(
                        reader["ID_Empleado"].ToString(),
                        reader["REF_Rol"].ToString(),
                        reader["Nombre_E"].ToString(),
                        reader["ApellidoP_E"].ToString(),
                        reader["ApellidoM_E"].ToString(),
                        reader["Cedula_E"].ToString(),
                        reader["Sexo_E"].ToString(),
                        reader["F_Nacimiento_E"].ToString(),
                        reader["Depto_E"].ToString(),
                        reader["Ciudad_E"].ToString(),
                        reader["Direccion_E"].ToString(),
                        reader["Mail_E"].ToString(),
                        reader["Celular_E"].ToString(),
                        reader["Tdoc_E"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los empleados: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (cmd_sqlite != null)
                    cmd_sqlite.Dispose();
            }
        }


    }


    public class usuariodb
    {
        SQLiteConnection conexion_sqlite;
        SQLiteCommand cmd_sqlite;
        private ClsEmpleado clsempleado;

        public void CrearTablaUsuario()
        {
            try
            {
                SQLiteConnection conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                SQLiteCommand cmd_sqlite = conexion_sqlite.CreateCommand();

                cmd_sqlite.CommandText = @"
            CREATE TABLE Usuario (
                ID_Usuario INTEGER PRIMARY KEY,
                User TEXT NOT NULL UNIQUE,
                Pasword TEXT NOT NULL,
                REF_Empleado INTEGER NOT NULL,
                FOREIGN KEY (REF_Empleado) REFERENCES Empleado(ID_Empleado)
            );";

                cmd_sqlite.ExecuteNonQuery();
                MessageBox.Show("Tabla Usuario creada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la tabla Usuario: " + ex.Message);
            }
        


    }


        public void InsertarUsuario(ClsUser usr, int idEmpleado)
        {
            try
            {
                SQLiteConnection conexion_sqlite = ConexionSQLite.Instancia.ObtenerConexion();
                SQLiteCommand cmd_sqlite = conexion_sqlite.CreateCommand();

                // Asegúrate de que los nombres de columnas no sean palabras reservadas o ponlos entre comillas dobles
                cmd_sqlite.CommandText = $@"
            INSERT INTO Usuario 
            (""User"", ""Pasword"", REF_Empleado)
            VALUES ('{usr.Usuario}', '{usr.Contraseña}', {idEmpleado});";

                // Puedes mostrar esto como depuración temporal
                MessageBox.Show($"Insertando usuario: {usr.Usuario} con ID de empleado: {idEmpleado}");

                cmd_sqlite.ExecuteNonQuery();

                MessageBox.Show($"Usuario registrado correctamente con ID de empleado: {idEmpleado}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message);
            }
        }


    }
} 

