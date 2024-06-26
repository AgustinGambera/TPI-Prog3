using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace RestauranteApp
{
    public partial class ModoEdicionControl : UserControl
    {
        private PictureBox selectedPictureBox;
        private Point offset;
        public event EventHandler? BackToMainFormRequested;
        public event EventHandler? BackToPreviewFormRequested;

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
                Size originalSize = (Size)e.Data.GetData("PictureBoxSize");
                string imagePath = (string)e.Data.GetData("ImagePath");

                PictureBox picBox = new PictureBox
                {
                    Image = bmp,
                    Location = panelEdicion.PointToClient(new Point(e.X, e.Y)),
                    Size = originalSize,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = Guid.NewGuid(), // Asigna un nuevo GUID como Tag
                    BackColor = Color.FromArgb(255, 255, 225)
                };

                picBox.MouseDown += PictureBox_MouseDownForPanel;
                picBox.MouseMove += PictureBox_MouseMoveForPanel;
                picBox.MouseUp += PictureBox_MouseUpForPanel;
                picBox.MouseClick += PictureBox_MouseClickForPanel;

                panelEdicion.Controls.Add(picBox);

                Element nuevoElemento = new Element
                {
                    Id = (Guid)picBox.Tag, // Usa el mismo GUID
                    ImagePath = imagePath,
                    Position = picBox.Location,
                    Size = originalSize,
                    Estado = "Libre",
                    MozoEncargado = "N/A",
                    Cliente = "N/A",
                    Permanencia = "N/A",
                    Consumos = "N/A",
                    BackColor = Color.FromArgb(255, 255, 225)
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
                var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Id == (Guid)selectedPictureBox.Tag);
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
            PictureBox pb = sender as PictureBox;
            if (e.Button == MouseButtons.Right)
            {
                // Eliminar el PictureBox al hacer clic con el botón derecho
               
                if (pb != null)
                {
                    this.Controls.Remove(pb);
                    pb.Dispose();

                    var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Position == pb.Location);
                    if (elemento != null)
                    {
                        layoutManager.EliminarElemento(elemento);
                    }
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                pb.BackColor = Color.Red;
            }
        }

        private void PictureBox_MouseClickForPanel(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Eliminar el PictureBox del panel
                    panelEdicion.Controls.Remove(pb);
                    pb.Dispose();

                    // Eliminar el elemento del LayoutManager
                    var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Position == pb.Location);
                    if (elemento != null)
                    {
                        layoutManager.EliminarElemento(elemento);
                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    // Cambiar el color de fondo del PictureBox
                    if (pb.BackColor == Color.FromArgb(255, 99, 71))
                    {
                        pb.BackColor = Color.FromArgb(255, 165, 0);
                    }
                    else if (pb.BackColor == Color.FromArgb(255, 165, 0))
                    {
                        pb.BackColor = Color.FromArgb(144, 238, 144);
                    }
                    else // por defecto, o en caso de Green
                    {
                        pb.BackColor = Color.FromArgb(255, 99, 71);
                    }

                    // Actualizar el BackColor del elemento en el LayoutManager
                    var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Position == pb.Location);
                    if (elemento != null)
                    {
                        elemento.BackColor = pb.BackColor;

                        // Actualizar el estado del elemento en función del color de fondo
                        if (elemento.BackColor == Color.FromArgb(255, 99, 71))
                        {
                            elemento.Estado = "Ocupada";
                        }
                        else if (elemento.BackColor == Color.FromArgb(255, 165, 0))
                        {
                            elemento.Estado = "Reservado";
                        }
                        else if (elemento.BackColor == Color.FromArgb(144, 238, 144))
                        {
                            elemento.Estado = "Libre";
                        }

                        MessageBox.Show($"Nuevo color: {pb.BackColor}");
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
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var elementos = layoutManager.ObtenerElementos();

                    // Convertir elementos a una lista de objetos anónimos para la serialización
                    var elementosSerializables = elementos.Select(el => new
                    {
                        Id = el.Id,
                        ImagePath = el.ImagePath,
                        Position = el.Position,
                        Size = el.Size,
                        BackColor = new { el.BackColor.R, el.BackColor.G, el.BackColor.B, el.BackColor.A }, // Guardar los componentes del color
                        Estado = el.Estado,
                        MozoEncargado = el.MozoEncargado,
                        Cliente = el.Cliente,
                        Permanencia = el.Permanencia,
                        Consumos = el.Consumos
                    }).ToList();

                    string json = JsonConvert.SerializeObject(elementosSerializables, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(saveFileDialog.FileName, json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el layout: {ex.Message}", "Error al guardar layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Boton cargar con la logica para cargar los elementos
        private void botonCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var elementosSerializables = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    // Limpiar los PictureBox actuales
                    panelEdicion.Controls.Clear();

                    foreach (var el in elementosSerializables)
                    {
                        // Convertir el objeto dinámico a un Element
                        Element elemento = new Element
                        {
                            Id = el.Id,
                            ImagePath = el.ImagePath,
                            Position = el.Position.ToObject<Point>(),
                            Size = el.Size.ToObject<Size>(),
                            BackColor = Color.FromArgb(el.BackColor.A, el.BackColor.R, el.BackColor.G, el.BackColor.B),
                            Estado = el.Estado,
                            MozoEncargado = el.MozoEncargado,
                            Cliente = el.Cliente,
                            Permanencia = el.Permanencia,
                            Consumos = el.Consumos
                        };

                        // Crear PictureBox para cada elemento cargado
                        PictureBox picBox = new PictureBox
                        {
                            Image = Image.FromFile(elemento.ImagePath),
                            Location = elemento.Position,
                            Size = elemento.Size,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = elemento.ImagePath,
                            BackColor = elemento.BackColor
                        };

                        picBox.MouseDown += PictureBox_MouseDownForPanel;
                        picBox.MouseMove += PictureBox_MouseMoveForPanel;
                        picBox.MouseUp += PictureBox_MouseUpForPanel;
                        picBox.MouseClick += PictureBox_MouseClickForPanel;

                        panelEdicion.Controls.Add(picBox);

                        // Agregar el elemento al LayoutManager
                        layoutManager.AgregarElemento(elemento);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el layout: {ex.Message}", "Error al cargar layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty);
        }

        private void previsualizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackToPreviewFormRequested?.Invoke(this, EventArgs.Empty);
        }

       
    }
}
