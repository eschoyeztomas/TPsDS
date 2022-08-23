using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PobreTITO
{
    internal class GestorPobreTITO
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Usuario\Downloads\UTN\3er AÑO\Diseño de Sistemas\TPsDS\TPsDS\PobreTITO\PobreTITO\PobreTITO\BD\BD_PobreTITO.mdf"";Integrated Security=True");
        int id_persona;
        public void gestionarRegistro(string nombreApellido, string dni, DateOnly fechaNacimiento, string telefono, string email, string usuario, string contraseña)
        {
            Persona persona = new Persona(nombreApellido, dni, fechaNacimiento, telefono, email, usuario, contraseña);
            var validacion = new Validaciones();
            var results = validacion.Validate(persona);
            if(!results.IsValid)
            {
                MessageBox.Show("Datos inválidos");
            }
            else
            {
                conexion.Open();
                persona.NuevaPersona(conexion);
                MessageBox.Show("Persona Registrada Exitosamente");
                conexion.Close();
            }
        }
        public bool iniciarSesion(string usuario, string contraseña)
        {
            /* 
             "PRUEBA INICIO SESIÓN"
             USUARIO: usuario1
             CONTRASEÑA: contraseña1 
            */

            conexion.Open();
            SqlCommand iniciarSesion = new SqlCommand($"select Id, usuario, contraseña from Persona where usuario = '{usuario}'", conexion);
            SqlDataReader lector = iniciarSesion.ExecuteReader();
            if(lector.Read())
            {
                id_persona = lector.GetInt32(0);
                if (contraseña == lector.GetString(2))
                {
                    MessageBox.Show("Sesión iniciada con éxito");
                    conexion.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                    conexion.Close();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
                conexion.Close();
                return false;
            }
        }
        public void registrarReclamo(string direccion, string descripcion, int subincidente)
        {
            conexion.Open();
            Reclamo reclamo = new Reclamo(direccion, descripcion);
            reclamo.nuevoReclamo(id_persona, subincidente, conexion);
            conexion.Close();
            MessageBox.Show("Reclamo registrado");
        }
    }
}
