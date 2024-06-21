using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RestauranteApp
{
    public partial class ModoEdicion : Form
    {
        private PictureBox selectedPictureBox;
        private Point offset;

        public ModoEdicion()
        {
            InitializeComponent();

            // Colección de PictureBox
            List<PictureBox> pictureBoxes = new List<PictureBox>
            {
                ItemsPicBox1, // Asegúrate de que estos nombres coincidan con los nombres de tus PictureBox
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
                pb.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
            }

            // Configurar los eventos de arrastre en el panel de destino
            panelEdicion.AllowDrop = true;
            panelEdicion.DragEnter += new DragEventHandler(panelEdicion_DragEnter);
            panelEdicion.DragDrop += new DragEventHandler(panelEdicion_DragDrop);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void previsualizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ModoPrevisualizacion modoPrevisualizacion = new ModoPrevisualizacion();
            modoPrevisualizacion.FormClosed += (s, args) => Show();
            modoPrevisualizacion.Show();
        }

        private void inicioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            Form1Principal form1Principal = new Form1Principal();
            form1Principal.FormClosed += (s, args) => Show();
            form1Principal.Show();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                pb.DoDragDrop(pb.Image, DragDropEffects.Copy);
            }
        }

        private void panelEdicion_DragEnter(object sender, DragEventArgs e)
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

        private void panelEdicion_DragDrop(object sender, DragEventArgs e)
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
                picBox.MouseDown += new MouseEventHandler(picBox_MouseDown);
                picBox.MouseMove += new MouseEventHandler(picBox_MouseMove);
                picBox.MouseUp += new MouseEventHandler(picBox_MouseUp);

                panelEdicion.Controls.Add(picBox);
            }
        }

        // Eventos para mover los PictureBox dentro del panel de edición
        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPictureBox = sender as PictureBox;
                offset = new Point(e.X, e.Y);
            }
        }

        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedPictureBox != null)
            {
                Point newLocation = selectedPictureBox.Location;
                newLocation.X += e.X - offset.X;
                newLocation.Y += e.Y - offset.Y;
                selectedPictureBox.Location = newLocation;
            }
        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPictureBox = null;
            }
        }

        // Botón Inicio que nos lleva al form principal
        private void BotonInicioEdicion_Click_1(object sender, EventArgs e)
        {
            Hide();
            Form1Principal form1Principal = new Form1Principal();
            form1Principal.FormClosed += (s, args) => Show();
            form1Principal.Show();
        }

        // Botón Previsualización que nos lleva al form de previsualización
        private void BotonPrevisualizacionEdicion_Click(object sender, EventArgs e)
        {
            Hide();
            ModoPrevisualizacion modoPrevisualizacion = new ModoPrevisualizacion();
            modoPrevisualizacion.FormClosed += (s, args) => Show();
            modoPrevisualizacion.Show();
        }
    }
}
