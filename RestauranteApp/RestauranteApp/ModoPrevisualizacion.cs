﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestauranteApp
{
    public partial class ModoPrevisualizacion : Form
    {
        public ModoPrevisualizacion()
        {
            InitializeComponent();
        }

        private void edicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir el modo edición cuando el usuario haga clic en el botón correspondiente
            Hide();
            ModoEdicion modoEdicion = new ModoEdicion();
            modoEdicion.FormClosed += (s, args) => Show();  // Mostrar el formulario principal al cerrar modo edición
            modoEdicion.Show();
        }

        // boton Inicio del form previsualizacion que, al dar clic nos lleva al formPrincipal
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir el modo edición cuando el usuario haga clic en el botón correspondiente
            Hide();
            Form1Principal form1Principal = new Form1Principal();
            form1Principal.FormClosed += (s, args) => Show();  // Mostrar el formulario principal al cerrar modo edición
            form1Principal.Show();
        }

      
    }
}
