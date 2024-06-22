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
    public partial class ModoEdicionControl : UserControl
    {
        private PictureBox selectedPictureBox;
        private Point offset;
        public event EventHandler BackToMainFormRequested;

        public ModoEdicionControl()
        {
            InitializeComponent();

            // Colección de PictureBox
            List<PictureBox> pictureBoxes = new List<PictureBox>
            {
                ItemsPicBox1,
                ItemsPicBox2,
                ItemsPicBox3,
                ItemsPicBox4,
                ItemsPicBox5,
                ItemsPicBox6,
                ItemsPicBox7
            };

            // Asignar el evento MouseDown a cada PictureBox
            foreach (var pb in pictureBoxes)
            {
                pb.MouseDown += PictureBox_MouseDown;
            }

            // Configurar los eventos de arrastre en el panel de destino
            panelEdicion.AllowDrop = true;
            panelEdicion.DragEnter += PanelEdicion_DragEnter;
            panelEdicion.DragDrop += PanelEdicion_DragDrop;
        }

        private void PanelEdicion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PanelEdicion_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                Bitmap bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                PictureBox picBox = new PictureBox
                {
                    Image = bmp,
                    Location = panelEdicion.PointToClient(new Point(e.X, e.Y)),
                    Size = new Size(50, 50),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                // Añadir eventos para permitir mover el PictureBox dentro del panel
                picBox.MouseDown += PictureBox_MouseDownForPanel;
                picBox.MouseMove += PictureBox_MouseMoveForPanel;
                picBox.MouseUp += PictureBox_MouseUpForPanel;

                panelEdicion.Controls.Add(picBox);
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                pb.DoDragDrop(pb.Image, DragDropEffects.Copy);
            }
        }

        private void PictureBox_MouseDownForPanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPictureBox = sender as PictureBox;
                offset = new Point(e.X, e.Y);
            }
        }

        private void PictureBox_MouseMoveForPanel(object sender, MouseEventArgs e)
        {
            if (selectedPictureBox != null)
            {
                Point newLocation = selectedPictureBox.Location;
                newLocation.X += e.X - offset.X;
                newLocation.Y += e.Y - offset.Y;
                selectedPictureBox.Location = newLocation;
            }
        }

        private void PictureBox_MouseUpForPanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPictureBox = null;
            }
        }

        public void BotonInicioEdicion_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}