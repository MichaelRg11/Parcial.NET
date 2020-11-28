using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Appwebfacturacion.Controller;
using Appwebfacturacion.Model;

namespace Appwebfacturacion
{
    /// <summary>
    /// Descripción breve de WSfacturacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSfacturacion : System.Web.Services.WebService
    {

        public WSfacturacion()
        {
            Mysqlcon.Open();
        }

        [WebMethod]
        public Cliente Buscarid(int id)
        {
            Cliente ob;
            ob = Clientedb.Buscar(id);
            return ob;
        }

        [WebMethod]
        public List<Cliente> ListarCliente()
        {
            List<Cliente> list;
            list = Clientedb.getAll();
            return list;
        }

        [WebMethod]
        public List<Producto> BuscarProductoVenta(int idventa)
        {
            List<Producto> list;
            list = Clientedb.DetalleVentaCliente(idventa);
            return list;
        }

        [WebMethod]
        public List<Venta> BuscarVentaCliente(int idventacl)
        {
            List<Venta> list;
            list = Clientedb.Buscardatos(idventacl);
            return list;
        }

        [WebMethod]
        public Venta BuscarVenta(int idventa)
        {
            Venta ob;
            ob = Clientedb.BuscarDatosVenta(idventa);
            return ob;
        }

    }
}
