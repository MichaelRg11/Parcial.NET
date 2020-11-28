using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appwebfacturacion.Controller;
using Appwebfacturacion.Model;

namespace Appwebfacturacion
{
    public partial class _Default : Page
    {
        WSfacturacion ws = new WSfacturacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                cbxclientes.DataValueField = "id";
                cbxclientes.DataTextField = "nombres";
                cbxclientes.DataSource = ws.ListarCliente();
                cbxclientes.DataBind();
            }
        }

        public void limpiar()
        {
            txtid.Text = "";
            txtdocumento.Text = "";
            txtnombres.Text = "";
            txtdireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        protected void btnBuscarId_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                int id = Convert.ToInt32(txtid.Text);
                Cliente ob = ws.Buscarid(id);
                if (ob != null)
                {
                    txtnombres.Text = ob.Nombres;
                    txtdocumento.Text = ob.Documento;
                    txtdireccion.Text = ob.Direccion;
                    txtTelefono.Text = ob.Telefono;
                    txtCorreo.Text = ob.Correo;

                }
                else
                {
                    limpiar();
                    txtnombres.Text = "--No existe Cliente-------";

                }
            }
            else
            {
                txtnombres.Text = "--Debe ingresar el ID-------";
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            dtgListadoCliente.DataSource = ws.ListarCliente();
            dtgListadoCliente.DataBind();
        }

        protected void cbxclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cl;
            Cliente ob;
            cl = Convert.ToInt32(cbxclientes.SelectedValue);
            ob = ws.Buscarid(cl);
            txtid.Text = Convert.ToString(ob.Id);
            txtnombres.Text= ob.Nombres + "- " +ob.Apellidos;
            txtdocumento.Text = ob.Documento;
            txtdireccion.Text = ob.Direccion;
            txtTelefono.Text = ob.Telefono;
            txtCorreo.Text = ob.Correo;
            cbxventa.DataValueField = "id";
            cbxventa.DataTextField = "numero";
            cbxventa.DataSource = ws.BuscarVentaCliente(ob.Id);
            cbxventa.DataBind();
            txtfecha.Text = "";
            txttotal.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int cl;
            cl = Convert.ToInt32(cbxventa.SelectedValue);
            Venta ob;
            ob = ws.BuscarVenta(cl);
            txtfecha.Text = ob.Fecha;
            var obProduct = ws.BuscarProductoVenta(cl);
            dtgListadoCliente.DataSource = null;
            dtgListadoCliente.DataSource = obProduct;
            dtgListadoCliente.DataBind();
            double Total = 0;
            foreach (var i in obProduct)
            {
                Total = Total + i.Precio * i.Cantidad;
            }
            txttotal.Text = Total + "";

        }
    }
}