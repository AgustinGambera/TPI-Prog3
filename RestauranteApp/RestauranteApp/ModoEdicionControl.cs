using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json; // Biblioteca para la serialización y deserialización JSON

namespace RestauranteApp
{
    public partial class ModoEdicionControl : UserControl
    {
        // Timer para distinguir entre clic y arrastre
        private System.Windows.Forms.Timer clickTimer;
        // PictureBox seleccionado para el arrastre
        private PictureBox selectedPictureBox;
        // Offset para calcular la nueva posición durante el arrastre
        private Point offset;
        // Eventos para navegar entre formularios
        public event EventHandler? BackToMainFormRequested;
        public event EventHandler? BackToPreviewFormRequested;

        // Booleano para controlar si se está arrastrando un elemento
        private bool isDragging;
        // Umbral de tiempo para distinguir entre clic y arrastre
        private const int ClickThreshold = 200;

        // Gestor de diseño para manejar los elementos en el panel
        private LayoutManager layoutManager;

        public ModoEdicionControl()
        {
            InitializeComponent();

            // Inicializar el Timer
            clickTimer = new System.Windows.Forms.Timer();
            clickTimer.Interval = ClickThreshold;
            clickTimer.Tick += ClickTimer_Tick;

            layoutManager = new LayoutManager();

            // Colección de PictureBox para los elementos
            List<PictureBox> pictureBoxes = new List<PictureBox>
            {
                ItemsPicBox1,
                ItemsPicBox2,
                ItemsPicBox3,
                ItemsPicBox4,
                ItemsPicBox5,
                ItemsPicBox6,
                ItemsPicBox7,
                ItemsPicBox16,
                ItemsPicBox17,
                ItemsPicBox18
            };

            // Asignar los eventos MouseDown y MouseClick a cada PictureBox
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

        // Evento que se dispara cuando se entra un objeto arrastrado en el panel
        private void PanelEdicion_DragEnter(object sender, DragEventArgs e)
        {
            // Verificar si el objeto arrastrado es una imagen
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy; // Permitir la acción de copiar
            }
            else
            {
                e.Effect = DragDropEffects.None; // No permitir ninguna acción
            }
        }

        // Evento que se dispara cuando se presiona el botón del mouse en un PictureBox
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.Bitmap, pb.Image);
                data.SetData("PictureBoxSize", pb.Size); // Agregar el tamaño del PictureBox al objeto DataObject
                data.SetData("ImagePath", pb.Tag); // Agregar la ruta de la imagen al objeto DataObject
                pb.DoDragDrop(data, DragDropEffects.Copy); // Iniciar el arrastre con el efecto de copiar
            }
        }

        // Evento que se dispara cuando se suelta un objeto arrastrado en el panel
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
                    Name = "ItemsPicBox16", // Asigna el nombre aquí
                    Tag = Guid.NewGuid(),
                    BackColor = Color.FromArgb(255, 255, 225)
                };

                picBox.MouseDown += PictureBox_MouseDownForPanel;
                picBox.MouseMove += PictureBox_MouseMoveForPanel;
                picBox.MouseUp += PictureBox_MouseUpForPanel;
                picBox.MouseClick += PictureBox_MouseClickForPanel;

                panelEdicion.Controls.Add(picBox);

                // Asegúrate de crear una instancia de Mesa solo si el elemento tiene el color de fondo correcto
                if (picBox.BackColor == Color.FromArgb(255, 255, 225))
                {
                    Mesa nuevaMesa = new Mesa
                    {
                        Id = (Guid)picBox.Tag,
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

                    layoutManager.AgregarElemento(nuevaMesa);
                }
            }
        }


        // Evento que se dispara cuando se presiona el botón del mouse en un PictureBox del panel de edición
        private void PictureBox_MouseDownForPanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPictureBox = sender as PictureBox; // Establecer el PictureBox seleccionado
                offset = new Point(e.X, e.Y); // Establecer el offset para el arrastre
                isDragging = false; // Inicialmente no se está arrastrando
                clickTimer.Start(); // Iniciar el Timer para distinguir entre clic y arrastre
            }
        }

        // Evento que se dispara cuando se mueve el mouse sobre un PictureBox del panel de edición
        private void PictureBox_MouseMoveForPanel(object sender, MouseEventArgs e)
        {
            if (selectedPictureBox != null)
            {
                isDragging = true; // Se detectó un arrastre
                Point newLocation = selectedPictureBox.Location;
                newLocation.X += e.X - offset.X;
                newLocation.Y += e.Y - offset.Y;
                selectedPictureBox.Location = newLocation; // Actualizar la ubicación del PictureBox

                // Actualizar la posición en el LayoutManager
                var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Id == (Guid)selectedPictureBox.Tag);
                if (elemento != null)
                {
                    layoutManager.ActualizarPosicion(elemento, newLocation);
                }
            }
        }

        // Evento que se dispara cuando se suelta el botón del mouse en un PictureBox del panel de edición
        private void PictureBox_MouseUpForPanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickTimer.Stop(); // Detener el Timer
                selectedPictureBox = null; // Deseleccionar el PictureBox
            }
        }

        // Evento que se dispara cuando se hace clic en un PictureBox
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

                    // Eliminar el elemento correspondiente del LayoutManager
                    var elemento = layoutManager.ObtenerElementos().FirstOrDefault(el => el.Position == pb.Location);
                    if (elemento != null)
                    {
                        layoutManager.EliminarElemento(elemento);
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                pb.BackColor = Color.Red; // Cambiar el color de fondo al hacer clic con el botón izquierdo
            }
        }

        // Evento que se dispara cuando se hace clic en un PictureBox del panel de edición
        private void PictureBox_MouseClickForPanel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !isDragging)
            {
                // Cambiar el color de fondo del PictureBox solo si no se está arrastrando
                PictureBox pb = sender as PictureBox;
                if (pb != null)
                {
                    // Cambiar el color de fondo del PictureBox cíclicamente
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
                        else if (elemento.BackColor == Color.FromArgb(255, 255, 225))
                        {
                            elemento.Estado = "N/A";
                        }


                    }
                }
            }
        }

        // Evento que se dispara cuando el Timer de clic ha alcanzado el umbral
        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            clickTimer.Stop(); // Detener el Timer cuando el tiempo umbral ha pasado
        }

        // Evento para manejar el clic en el botón de inicio de edición
        public void BotonInicioEdicion_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty); // Invocar el evento para regresar al formulario principal
        }

        // Método para guardar el diseño al presionar el botón Guardar
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

                    // Serializar la lista de elementos a JSON
                    string json = JsonConvert.SerializeObject(elementosSerializables, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(saveFileDialog.FileName, json); // Escribir el JSON a un archivo
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el layout: {ex.Message}", "Error al guardar layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Botón para cargar el diseño desde un archivo JSON
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

                        // Asignar los eventos de manejo al PictureBox
                        picBox.MouseDown += PictureBox_MouseDownForPanel;
                        picBox.MouseMove += PictureBox_MouseMoveForPanel;
                        picBox.MouseUp += PictureBox_MouseUpForPanel;
                        picBox.MouseClick += PictureBox_MouseClickForPanel;

                        // Agregar el PictureBox al panel de edición
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

        // Evento para manejar el clic en el menú de inicio
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty); // Invocar el evento para regresar al formulario principal
        }

        // Evento para manejar el clic en el menú de previsualización
        private void previsualizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackToPreviewFormRequested?.Invoke(this, EventArgs.Empty); // Invocar el evento para ir al formulario de previsualización
        }

        private void panelEdicion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnModoPrevisualizacion_Click(object sender, EventArgs e)
        {
            BackToPreviewFormRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
