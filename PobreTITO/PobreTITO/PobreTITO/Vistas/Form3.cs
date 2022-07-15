using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PobreTITO
{
    public partial class Form3 : Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Usuario\Downloads\PobreTITO\PobreTITO\PobreTITO\BD\BD_PobreTITO.mdf;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }
        public void CargarIncidente()
        {
            conexion.Open();
            SqlCommand select = new SqlCommand("select * from Incidente", conexion);
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(select);
            adapter.Fill(datos);
            conexion.Close();
            cb_incidente.DisplayMember = "Tipo";
            cb_incidente.ValueMember = "Id";
            cb_incidente.DataSource = datos;
        }
        public void CargarSubincidente(int incidente_id)
        {
            conexion.Open();
            SqlCommand select = new SqlCommand($"select * from SubIncidente where Incidente_Id = {incidente_id}", conexion);
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(select);
            adapter.Fill(datos);
            conexion.Close();
            cb_sub_incidente.DataSource = datos;
            cb_sub_incidente.ValueMember = "Id";
            cb_sub_incidente.DisplayMember = "tipo";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarIncidente();
        }

        private void cb_incidente_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = (int)cb_incidente.SelectedValue;
            if((int)cb_incidente.SelectedIndex != -1)
            {
                CargarSubincidente(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.gestorPobreTITO.registrarReclamo(txt_direccion.Text, txt_descripcion.Text, (int)cb_sub_incidente.SelectedValue);
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form4.Show();
        }
    }
}
