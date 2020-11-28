using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appwebfacturacion.Model
{
    public class Cliente
    {
        private int id;
        private string documento;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string telefono;
        private string correo;

        public int Id { get => id; set => id = value; }
        public string Documento { get => documento; set => documento = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}