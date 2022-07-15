using System.Data.SqlClient;

namespace PobreTITO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Program.gestorPobreTITO.gestionarRegistro(nombreApellido.Text, dni.Text, DateOnly.Parse(fechaNacimiento.Text), telefono.Text, email.Text, usuario.Text, contraseña.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Datos incorrectos");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form4.Show();
        }
    }
}