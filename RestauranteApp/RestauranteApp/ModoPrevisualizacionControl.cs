using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RestauranteApp
{
    public partial class ModoPrevisualizacionControl : UserControl

    {
        private LayoutManager layoutManager;
        private ModoEdicionControl modoEdicion;
        private List<Mesa> mesas;
        //Evento para volver al form principal mediante boton de inicio
        public event EventHandler? BackToMainFormRequested;
        public event EventHandler? BackToEditFormRequested;

        public ModoPrevisualizacionControl()
        {
            InitializeComponent();
            layoutManager = new LayoutManager();
            CargarMesas();
            MostrarMesas();
            edicionToolStripMenuItem.Click += edicionToolStripMenuItem_Click;
            dgvDetallesMesa.CellEndEdit += dgvDetallesMesa_CellEndEdit;
        }

        private void CargarMesas()
        {
            mesas = layoutManager.ObtenerElementos().Where(e => e is Mesa).Select(e => (Mesa)e).ToList();
            AsignarNumerosDeMesa();
        }

        private void AsignarNumerosDeMesa()
        {
            for (int i = 0; i < mesas.Count; i++)
            {
                mesas[i].Numero = i + 1;
            }
        }


        private void MostrarMesas()
        {
            panelMesas.Controls.Clear();
            int x = 10, y = 10;
            foreach (var mesa in mesas)
            {
                var btnMesa = new Button
                {
                    Text = $"Mesa {mesa.Numero}\n{mesa.Estado}",
                    Size = new Size(100, 60),
                    Location = new Point(x, y),
                    BackColor = mesa.Estado == "Libre" ? Color.FromArgb(144, 238, 144) :
                                mesa.Estado == "Ocupada" ? Color.FromArgb(255, 99, 71) :
                                Color.FromArgb(255, 165, 0),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White
                };
                btnMesa.FlatAppearance.BorderSize = 0;
                btnMesa.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 130, 180);
                btnMesa.Click += (s, e) => MostrarDetallesMesa(mesa);
                panelMesas.Controls.Add(btnMesa);
                x += 110;
                if (x + 110 > panelMesas.Width)
                {
                    x = 10;
                    y += 70;
                }
            }
        }


        private void MostrarDetallesMesa(Mesa mesa)
        {
            var dt = new DataTable();
            dt.Columns.Add("Detalle");
            dt.Columns.Add("Información");
            dt.Columns.Add("Id", typeof(Guid)); // Añade una columna oculta para el identificador único de la mesa

            dt.Rows.Add("Numero", mesa.Numero, mesa.Id);
            dt.Rows.Add("Estado", mesa.Estado, mesa.Id);
            dt.Rows.Add("Mozo Encargado", mesa.MozoEncargado, mesa.Id);
            dt.Rows.Add("Cliente", mesa.Cliente, mesa.Id);
            dt.Rows.Add("Permanencia", mesa.Permanencia, mesa.Id);
            dt.Rows.Add("Consumos", mesa.Consumos, mesa.Id);

            dgvDetallesMesa.DataSource = dt;

            // Hacer que las columnas de información sean editables
            foreach (DataGridViewColumn column in dgvDetallesMesa.Columns)
            {
                if (column.Name == "Información")
                {
                    column.ReadOnly = false;
                }
                else
                {
                    column.ReadOnly = true;
                }
            }

            // Ocultar columnas no deseadas
            foreach (DataGridViewColumn column in dgvDetallesMesa.Columns)
            {
                if (column.Name == "Id")
                {
                    column.Visible = false;
                }
            }
        }


        private void btnGuardarJson_Click(object sender, EventArgs e)
        {
            SaveAsJSON();
        }

        private void SaveAsJSON()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string jsonString = JsonSerializer.Serialize(mesas, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(saveFileDialog.FileName, jsonString);
                    MessageBox.Show("Datos guardados en " + saveFileDialog.FileName, "Guardar JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnGuardarXML_Click(object sender, EventArgs e)
        {
            SaveAsXML();
        }

        private void SaveAsXML()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Mesa>));
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(fs, mesas);
                    }
                    MessageBox.Show("Datos guardados en " + saveFileDialog.FileName, "Guardar XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCargarJSON_Click(object sender, EventArgs e)
        {
            LoadFromJSON();
        }


        private void LoadFromJSON()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var options = new JsonSerializerOptions
                        {
                            Converters = { new PointConverter(), new SizeConverter() }
                        };
                        string jsonString = File.ReadAllText(openFileDialog.FileName);
                        var loadedMesas = JsonSerializer.Deserialize<List<Mesa>>(jsonString, options);

                        if (loadedMesas != null)
                        {
                            mesas = loadedMesas;
                            AsignarNumerosDeMesa(); // Asegurarse de asignar números de mesa después de cargar los datos

                            foreach (var mesa in mesas)
                            {
                                // Agregar solo mesas al LayoutManager
                                if (mesa.BackColor == Color.FromArgb(255, 255, 225))
                                {
                                    layoutManager.AgregarElemento(mesa);
                                }
                            }

                            MessageBox.Show("Datos cargados desde " + openFileDialog.FileName, "Cargar JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateUIWithMesasData();
                            MostrarMesas();
                        }
                        else
                        {
                            MessageBox.Show("Error al deserializar los datos.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar el archivo JSON: {ex.Message}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





        private void UpdateUIWithMesasData()
        {
            dgvDetallesMesa.DataSource = null;
            dgvDetallesMesa.DataSource = mesas;

            // Ocultar columnas no deseadas
            foreach (DataGridViewColumn column in dgvDetallesMesa.Columns)
            {
                if (column.Name == "Id" || column.Name == "ImagePath" || column.Name == "Size" || column.Name == "Position" || column.Name == "BackColor")
                {
                    column.Visible = false;
                }
            }
        }




        public class Mesa : Element
        {
            public int Numero { get; set; }

        }

        private void botonInicioPreview_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty);
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty);
        }

        private void edicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackToEditFormRequested?.Invoke(this, EventArgs.Empty);
        }

        private void dgvDetallesMesa_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetallesMesa.Columns[e.ColumnIndex].Name == "Información")
            {
                string detalle = dgvDetallesMesa.Rows[e.RowIndex].Cells["Detalle"].Value.ToString();
                string valor = dgvDetallesMesa.Rows[e.RowIndex].Cells["Información"].Value.ToString();
                Guid id = (Guid)dgvDetallesMesa.Rows[e.RowIndex].Cells["Id"].Value;
                ActualizarMesa(detalle, valor, id);
            }
        }

        private void ActualizarMesa(string detalle, string valor, Guid id)
        {
            var mesa = mesas.FirstOrDefault(m => m.Id == id);
            if (mesa != null)
            {
                switch (detalle)
                {
                    case "Mozo Encargado":
                        mesa.MozoEncargado = valor;
                        break;
                    case "Cliente":
                        mesa.Cliente = valor;
                        break;
                    case "Permanencia":
                        mesa.Permanencia = valor;
                        break;
                    case "Consumos":
                        mesa.Consumos = valor;
                        break;
                }
            }
        }
    }
}