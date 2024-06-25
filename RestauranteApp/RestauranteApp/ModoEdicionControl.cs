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
                ItemsPicBox16,
                ItemsPicBox17,
                ItemsPicBox18
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

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.Bitmap, pb.Image);
                data.SetData("PictureBoxSize", pb.Size); // Agregar el tamaño del PictureBox al objeto DataObject
                data.SetData("ImagePath", pb.Tag); // Agregar la ruta de la imagen al objeto DataObject
                pb.DoDragDrop(data, DragDropEffects.Copy);
            }
        }

        private void PanelEdicion_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && e.Data.GetDataPresent("PictureBoxSize") && e.Data.GetDataPresent("ImagePath"))
            {
                Bitmap bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                Size originalSize = (Size)e.Data.GetData("PictureBoxSize"); // Obtener el tamaño original del PictureBox
                string imagePath = (string)e.Data.GetData("ImagePath"); // Obtener la ruta de la imagen

                PictureBox picBox = new PictureBox
                {
                    Image = bmp,
                    Location = panelEdicion.PointToClient(new Point(e.X, e.Y)),
                    Size = originalSize, // Usar el tamaño original
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = imagePath // Configurar la ruta de la imagen en la propiedad Tag
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
                    ImagePath = imagePath,
                    Position = picBox.Location
                };
                layoutManager.AgregarElemento(nuevoElemento);
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

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                layoutManager.GuardarLayout(saveFileDialog.FileName);
            }
        }

        // Boton cargar con la logica para cargar los elementos
        private void botonCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    layoutManager.CargarLayout(openFileDialog.FileName);

                    // Limpiar los PictureBox actuales
                    panelEdicion.Controls.Clear();

                    // Crear PictureBox para cada elemento cargado
                    foreach (var elemento in layoutManager.ObtenerElementos())
                    {
                        // Comprobar si ImagePath es válido
                        if (!string.IsNullOrEmpty(elemento.ImagePath) && File.Exists(elemento.ImagePath))
                        {
                            try
                            {
                                PictureBox picBox = new PictureBox
                                {
                                    Image = Image.FromFile(elemento.ImagePath),
                                    Location = elemento.Position,
                                    Size = elemento.Size, // Usar el tamaño guardado
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Tag = elemento.ImagePath
                                };

                                // Añadir eventos para permitir mover el PictureBox dentro del panel
                                picBox.MouseDown += PictureBox_MouseDownForPanel;
                                picBox.MouseMove += PictureBox_MouseMoveForPanel;
                                picBox.MouseUp += PictureBox_MouseUpForPanel;
                                picBox.MouseClick += PictureBox_MouseClickForPanel; // Añadir evento para eliminar con clic derecho

                                panelEdicion.Controls.Add(picBox);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al cargar la imagen '{elemento.ImagePath}': {ex.Message}", "Error al cargar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"La ruta de la imagen '{elemento.ImagePath}' no es válida.", "Error al cargar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el layout: {ex.Message}", "Error al cargar layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
