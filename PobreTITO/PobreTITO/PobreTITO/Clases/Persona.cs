using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PobreTITO
{
    internal class Persona
    {
        public string nombreApellido { get; set; }
        public string dni { get; set; }
        public DateOnly fechaNacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }

        public Persona (string nombreApellido, string dni, DateOnly fechaNacimiento, string telefono, string email, string usuario, string contraseña)
        {
            this.nombreApellido = nombreApellido;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.email = email;
            this.usuario = usuario;
            this.contraseña = contraseña;
        }
        public void NuevaPersona(SqlConnection connection)
        {
            SqlCommand insert = new SqlCommand($"insert into Persona values('{dni}', '{nombreApellido}', '{fechaNacimiento}', '{telefono}', '{email}', '{usuario}', '{contraseña}')", connection);
            insert.ExecuteNonQuery();
        }
    }

}