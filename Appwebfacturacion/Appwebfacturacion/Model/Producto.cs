using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appwebfacturacion.Model
{
    public class Producto
    {
        private string id;
        private string descripcion;
        private double precio;
        private int cantidad;

        public string Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}