using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RestauranteApp
{
    public partial class ModoEdicionControl : UserControl
    {
        private PictureBox selectedPictureBox;
        private Point offset;
        public event EventHandler BackToMainFormRequested;

        private LayoutManager layoutManager;

        public ModoEdicionControl()
        {
            InitializeComponent();

            layoutManager = new LayoutManager();

            // Colección de PictureBox
            List<PictureBox> pictureBoxes = new List<PictureBox>
            {
                ItemsPicBox1,
                ItemsPicBox2,
                ItemsPicBox3,
                ItemsPicBox4,
                ItemsPicBox5,
                ItemsPicBox6,
                ItemsPicBox7,
                ItemsPicBox8,
                ItemsPicBox9,
                ItemsPicBox10,
                ItemsPicBox11,
                ItemsPicBox12,
                ItemsPicBox13,
                ItemsPicBox14,
                ItemsPicBox15,
            };

            // Asignar el evento MouseDown y MouseClick a cada PictureBox
            foreach (var pb in pictureBoxes)
            {
                pb.MouseDown += PictureBox_MouseDown;
                pb.MouseClick += PictureBox_MouseClick;
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
                picBox.MouseClick += PictureBox_MouseClickForPanel; // Añadir evento para eliminar con clic derecho

                panelEdicion.Controls.Add(picBox);

                // Agregar el nuevo elemento al LayoutManager
                Element nuevoElemento = new Element
                {
                    Id = Guid.NewGuid(),
                    ImageLocation = bmp, // Requiere modificar la clase Element para aceptar Bitmaps
                    Position = picBox.Location
                };
                layoutManager.AgregarElemento(nuevoElemento);
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

                // Actualizar la posición en el LayoutManager
                var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Position == selectedPictureBox.Location);
                if (elemento != null)
                {
                    layoutManager.ActualizarPosicion(elemento, newLocation);
                }
            }
        }

        private void PictureBox_MouseUpForPanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPictureBox = null;
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Eliminar el PictureBox del panel
                PictureBox pb = sender as PictureBox;
                if (pb != null)
                {
                    this.Controls.Remove(pb);
                    pb.Dispose();
                }
            }
        }

        private void PictureBox_MouseClickForPanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Eliminar el PictureBox del panel
                PictureBox pb = sender as PictureBox;
                if (pb != null)
                {
                    panelEdicion.Controls.Remove(pb);
                    pb.Dispose();

                    // Eliminar el elemento del LayoutManager
                    var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Position == pb.Location);
                    if (elemento != null)
                    {
                        layoutManager.EliminarElemento(elemento);
                    }
                }
            }
        }

        public void BotonInicioEdicion_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty);
        }

        // Método para guardar el layout al presionar el botón Guardar
        public void BotonGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                layoutManager.GuardarLayout(saveFileDialog.FileName);
            }
        }


        // Método para cargar el layout al presionar el botón Cargar
        /*
        public void BotonCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                layoutManager.CargarLayout(openFileDialog.FileName);

                // Limpiar el panel antes de cargar
                panelEdicion.Controls.Clear();

                // Cargar los elementos desde el LayoutManager
                foreach (var elemento in layoutManager.ObtenerElementos())
                {
                    PictureBox picBox = new PictureBox
                    {
                        Image = elemento.ImageLocation, // Requiere modificar la clase Element para aceptar Bitmaps
                        Location = elemento.Position,
                        Size = new Size(50, 50),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    // Añadir eventos para permitir mover el PictureBox dentro del panel
                    picBox.MouseDown += PictureBox_MouseDownForPanel;
                    picBox.MouseMove += PictureBox_MouseMoveForPanel;
                    picBox.MouseUp += PictureBox_MouseUpForPanel;
                    picBox.MouseClick += PictureBox_MouseClickForPanel; // Añadir evento para eliminar con clic derecho

                    panelEdicion.Controls.Add(picBox);
                }
            }
        }
        */
    }
}
