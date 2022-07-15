﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PobreTITO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool condicion = Program.gestorPobreTITO.iniciarSesion(usuarioIS.Text, contraseñaIS.Text);
            if(condicion)
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();
                this.Hide();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form4.Show();
        }
    }
}
