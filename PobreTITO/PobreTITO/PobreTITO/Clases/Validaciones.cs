using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Data.SqlClient;

namespace PobreTITO
{
    internal class Validaciones : AbstractValidator<Persona>
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Usuario\Downloads\UTN\3er AÑO\Diseño de Sistemas\TPsDS\TPsDS\PobreTITO\PobreTITO\PobreTITO\BD\BD_PobreTITO.mdf"";Integrated Security=True");
        public Validaciones()
        {
            RuleFor(x => x.nombreApellido).NotEmpty().MaximumLength(50);
            RuleFor(x => x.dni).NotEmpty().MaximumLength(8).MinimumLength(7);
            RuleFor(x => x.fechaNacimiento).NotEmpty().Must(VerNac);
            RuleFor(x => x.telefono).NotEmpty().Length(10);
            RuleFor(x => x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.usuario).NotEmpty().MaximumLength(20).Must(UsuarioRepetido);
            RuleFor(x => x.contraseña).NotEmpty().MaximumLength(20);
        }
        private bool VerNac(DateOnly time)
        {
            if (time.Year > 1900 && time.Year < DateTime.Now.Year)
            {
                return true;
            }
            return false;
        }
        private bool UsuarioRepetido(string usuario)
        {
            conexion.Open();
            SqlCommand usuarioRepetido = new SqlCommand($"select Id, usuario, contraseña from Persona where usuario = '{usuario}'", conexion);
            SqlDataReader lector = usuarioRepetido.ExecuteReader();
            if (lector.Read())
            {
                lector.Close();
                conexion.Close();
                return false;
            }
            else
            {
                lector.Close();
                conexion.Close();
                return true;
            }
        }
    }
}
