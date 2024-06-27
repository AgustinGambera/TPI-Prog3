using System;

public class DetallesMesaDialog : Form
{
    private TextBox txtEstado;
    private TextBox txtMozoEncargado;
    private TextBox txtCliente;
    private TextBox txtPermanencia;
    private TextBox txtConsumos;

    public string Estado { get { return txtEstado.Text; } }
    public string MozoEncargado { get { return txtMozoEncargado.Text; } }
    public string Cliente { get { return txtCliente.Text; } }
    public string Permanencia { get { return txtPermanencia.Text; } }
    public string Consumos { get { return txtConsumos.Text; } }

    public DetallesMesaDialog()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "Detalles de la Mesa";
        this.Size = new Size(300, 250);

        Label lblEstado = new Label();
        lblEstado.Text = "Estado:";
        lblEstado.Location = new Point(20, 20);

        txtEstado = new TextBox();
        txtEstado.Location = new Point(120, 20);
        txtEstado.Size = new Size(150, 20);

        Label lblMozoEncargado = new Label();
        lblMozoEncargado.Text = "Mozo Encargado:";
        lblMozoEncargado.Location = new Point(20, 50);

        txtMozoEncargado = new TextBox();
        txtMozoEncargado.Location = new Point(120, 50);
        txtMozoEncargado.Size = new Size(150, 20);

        Label lblCliente = new Label();
        lblCliente.Text = "Cliente:";
        lblCliente.Location = new Point(20, 80);

        txtCliente = new TextBox();
        txtCliente.Location = new Point(120, 80);
        txtCliente.Size = new Size(150, 20);

        Label lblPermanencia = new Label();
        lblPermanencia.Text = "Permanencia:";
        lblPermanencia.Location = new Point(20, 110);

        txtPermanencia = new TextBox();
        txtPermanencia.Location = new Point(120, 110);
        txtPermanencia.Size = new Size(150, 20);

        Label lblConsumos = new Label();
        lblConsumos.Text = "Consumos:";
        lblConsumos.Location = new Point(20, 140);

        txtConsumos = new TextBox();
        txtConsumos.Location = new Point(120, 140);
        txtConsumos.Size = new Size(150, 20);

        Button btnAceptar = new Button();
        btnAceptar.Text = "Aceptar";
        btnAceptar.Location = new Point(100, 180);
        btnAceptar.DialogResult = DialogResult.OK;
        this.AcceptButton = btnAceptar;

        this.Controls.Add(lblEstado);
        this.Controls.Add(txtEstado);
        this.Controls.Add(lblMozoEncargado);
        this.Controls.Add(txtMozoEncargado);
        this.Controls.Add(lblCliente);
        this.Controls.Add(txtCliente);
        this.Controls.Add(lblPermanencia);
        this.Controls.Add(txtPermanencia);
        this.Controls.Add(lblConsumos);
        this.Controls.Add(txtConsumos);
        this.Controls.Add(btnAceptar);
    }
}

