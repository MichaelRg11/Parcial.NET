using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWSfacturacion
{
    public partial class Form1 : Form
    {
        localhost.WSfacturacion ws = new localhost.WSfacturacion();
        public Form1()
        {
            InitializeComponent();
           
        }

        public void LimpiarVentas()
        {
            txtFecha.Clear();
            txtTotal.Clear();
            dtgDetalle.DataSource = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            var cl = ws.ListarCliente();
            cbxCliente.DisplayMember = "nombres";
            cbxCliente.ValueMember = "id";
            cbxCliente.DataSource = cl;
            cbxCliente.SelectedIndex = -1;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(cbxCliente.SelectedValue);
            var clb = ws.Buscarid(id);
            txtDireccion.Text = clb.Direccion;
            txtEmail.Text = clb.Correo;
            txtTelefono.Text = clb.Telefono;
            var vt = ws.BuscarVentaCliente(id);
            cbxVentas.DisplayMember = "numero";
            cbxVentas.ValueMember = "id";
            cbxVentas.DataSource = vt;
            cbxVentas.SelectedIndex = -1;
            LimpiarVentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idventa = Convert.ToInt32(cbxVentas.SelectedValue);
            var vtn = ws.BuscarVenta(idventa);
            txtFecha.Text = vtn.Fecha;
            var pr = ws.BuscarProductoVenta(idventa);
            dtgDetalle.DataSource = null;
            dtgDetalle.DataSource = pr;
            double total = 0;
            foreach (var i in pr)
            {
                total = total + (i.Precio* i.Cantidad);
            }
            txtTotal.Text= "$ " + total;
            dtgDetalle.Columns[4].Visible = false;
            dtgDetalle.Columns[5].Visible = false;
            dtgDetalle.Columns[6].Visible = false;
        }
    }
}
