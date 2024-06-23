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
    public partial class ModoPrevisualizacionControl : UserControl
    {
        public event EventHandler? BackToMainFormRequested;

        public ModoPrevisualizacionControl()
        {
            InitializeComponent();
            // Inicializar controles específicos del modo previsualización
        }

        private void BotonInicioPrevisualizacion_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}