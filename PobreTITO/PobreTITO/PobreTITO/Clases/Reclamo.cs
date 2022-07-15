using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PobreTITO
{
    internal class Reclamo
    {
        public DateTime fecha { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public Reclamo(string direccion, string descripcion)
        {
            this.direccion = direccion;
            this.descripcion = descripcion;
            fecha = DateTime.Now;
        }
        public void nuevoReclamo(int persona_id, int subindicidente_id, SqlConnection conexion)
        {
            SqlCommand insert = new SqlCommand($"insert into Reclamo values ('{fecha}', '{direccion}', '{descripcion}', {persona_id}, {subindicidente_id})", conexion);
            insert.ExecuteNonQuery();
        }
    }
}
