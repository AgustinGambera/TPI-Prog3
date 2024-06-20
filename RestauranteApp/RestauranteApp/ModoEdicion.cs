using System;
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
    public partial class ModoEdicion : Form
    {
        public ModoEdicion()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void previsualizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ModoPrevisualizacion modoPrevisualizacion = new ModoPrevisualizacion();
            modoPrevisualizacion.FormClosed += (s, args) => Show();  // Mostrar el formulario principal al cerrar modo previsualización
            modoPrevisualizacion.Show();
        }

       
    }
}
