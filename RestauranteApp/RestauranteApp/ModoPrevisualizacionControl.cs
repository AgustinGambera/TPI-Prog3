using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RestauranteApp
{
    public partial class ModoPrevisualizacionControl : UserControl

    {
        private List<Mesa> mesas;
        //Evento para volver al form principal mediante boton de inicio
        public event EventHandler? BackToMainFormRequested;

        public ModoPrevisualizacionControl()
        {
            InitializeComponent();
            CargarMesas();
            MostrarMesas();
        }

        private void CargarMesas()
        {
            mesas = new List<Mesa>
            {
                new Mesa { Numero = 1, Estado = "Libre", MozoEncargado = "Juan", Cliente = "N/A", Permanencia = "N/A", Consumos = "N/A" },
                new Mesa { Numero = 2, Estado = "Ocupada", MozoEncargado = "Ana", Cliente = "Carlos", Permanencia = "30 min", Consumos = "2 bebidas" },
                new Mesa { Numero = 3, Estado = "Reservada", MozoEncargado = "Luis", Cliente = "Matias", Permanencia = "N/A", Consumos = "N/A" }
            };
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
            dt.Rows.Add("Número de Mesa", mesa.Numero);
            dt.Rows.Add("Estado", mesa.Estado);
            dt.Rows.Add("Mozo Encargado", mesa.MozoEncargado);
            dt.Rows.Add("Cliente", mesa.Cliente);
            dt.Rows.Add("Permanencia", mesa.Permanencia);
            dt.Rows.Add("Consumos", mesa.Consumos);
            dgvDetallesMesa.DataSource = dt;
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
                    string jsonString = File.ReadAllText(openFileDialog.FileName);
                    mesas = JsonSerializer.Deserialize<List<Mesa>>(jsonString);
                    MessageBox.Show("Datos cargados desde " + openFileDialog.FileName, "Cargar JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateUIWithMesasData();
                    MostrarMesas();
                }
            }
        }

        private void UpdateUIWithMesasData()
        {
            dgvDetallesMesa.DataSource = null;
            dgvDetallesMesa.DataSource = mesas;
        }

       

        public class Mesa
        {
            public int Numero { get; set; }
            public string Estado { get; set; }
            public string MozoEncargado { get; set; }
            public string Cliente { get; set; }
            public string Permanencia { get; set; }
            public string Consumos { get; set; }
        }

        private void botonInicioPreview_Click(object sender, EventArgs e)
        {
            BackToMainFormRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}