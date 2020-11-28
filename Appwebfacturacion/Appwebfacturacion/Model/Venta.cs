using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appwebfacturacion.Model
{
    public class Venta
    {
        private int id;
        private string numero;
        private string fecha;
        private double subtotal;
        private double iva;
        private double descuento;
        private double total;
        private int idcliente;
        private int idvendedor;

        public int Id { get => id; set => id = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Total { get => total; set => total = value; }
        public int Idcliente { get => idcliente; set => idcliente = value; }
        public int Idvendedor { get => idvendedor; set => idvendedor = value; }
    }
}