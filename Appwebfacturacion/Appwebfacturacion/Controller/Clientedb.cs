using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appwebfacturacion.Controller;
using Appwebfacturacion.Model;
using MySql.Data.MySqlClient; //reconozca tipo de dato sql
using Newtonsoft.Json; //libreria json
using System.IO;//archivos lectura y escritura
using Newtonsoft.Json.Linq;


namespace Appwebfacturacion.Controller
{
    public class Clientedb
    {
        public static string SQL;

        public static List<Cliente> getAll()
        {
            List<Cliente> cl = null;
            Cliente ob;
            SQL = "Select * from clientes ORDER BY  apellidos,nombres";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            cl = new List<Cliente>();
            while (rg.Read())
            {
                ob = new Cliente();
                ob.Id = rg.GetInt32("id");//Campo DB
                ob.Documento = rg.GetString("documento");
               ob.Nombres = rg.GetString("nombres") +" - "+ rg.GetString("apellidos");               
               ob.Direccion = rg.GetString("direccion");
               ob.Telefono = rg.GetString("telefono");
                ob.Correo = rg.GetString("correo");
                cl.Add(ob);
            }
            rg.Close(); //CADA VEZ QUE TERMINE UNA CONSULTA
            return cl;
        } //end getall

        public static void Writejson()
        {
            string jsontext;
            List<Cliente> client = getAll();
            int c = 0;
            string path = "Clientes.json";
            StreamWriter fw = File.CreateText(path);//creando un archivo para escritura
            foreach(var reg in client)
            {
                jsontext = JsonConvert.SerializeObject(reg); //convirtiendo en un objeto tipo json
                c++;
               // Console.WriteLine("No. " + c + " "+jsontext);
                fw.WriteLine(jsontext);
                
            }
            Console.WriteLine("Creado el archivo 'Clientes.json' con  " + c + " registros!");
            fw.Close(); //Cierre el archivo
        }

        public static void clasified()
        {
            string path = "TestData.json";
            string sqlformat = "test.sql";
            string sql;
            string s = "";           
            if (!File.Exists(path))
            {
                Console.WriteLine("Archivo origen no existe");
                return;
            }
            StreamReader fr = File.OpenText(path);
            StreamWriter fW = File.CreateText(sqlformat);
            string id;
            string genero;
            int salario;
            int grado;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");
            int c = 0;
            while ((s= fr.ReadLine()) != null)
            {
                JObject rss = JObject.Parse(s);
                id = (string)rss["id"];
                genero = (string)rss["gender"];
                salario = (int)rss["salario"];
                grado = (int)rss["grado"];

                if (grado % 2 != 0 && salario > 2000000)
                {
                    c++;
                    sql = "insert into clasificados(id,genero,salario,grado,fecha) value (" + id + ",'" + genero + "'," + salario +
                    "," + grado + ",'" + fecha + "');";
                    fW.WriteLine(sql);
                }//end if
                
            }//end while
            Console.WriteLine("Creado el archivo 'test.sql' con  " + c + " registros!");
            fr.Close();
            fW.Close();
        }//end clasificado


        public static void Readjson()
        {
            string path = "Clientes.json";
            string s = "";
            if (!File.Exists(path))
            {
                Console.WriteLine("Archivo origen no existe");
                return;
            }
            StreamReader fr = File.OpenText(path);
            int c = 0;
            string id;
            string nombres;
            while ((s = fr.ReadLine()) != null) //lee linea por linea
            {
                JObject rss = JObject.Parse(s);
                id = (string)rss["Id"];
                Console.WriteLine("ID " + id);
                nombres = (string)rss["Nombres"] + " "+ (string)rss["Apellidos"];
                Console.WriteLine("Nombres " + nombres);
                c++;
               // Console.WriteLine("No. " + c + " " + s);
            }
            fr.Close();
        }
        public static void Guardar(Cliente cl)
        {

            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");
            SQL = "insert into clientes(documento, nombres, apellidos, direccion, telefono, correo, created, modified)" +
                "values ('" + cl.Documento + "','" + cl.Nombres + "','" + cl.Apellidos + "','" + cl.Direccion + "','" + cl.Telefono +
                "','" + cl.Correo + "','" + fecha + "','" + fecha + "')";
            Console.WriteLine(SQL);
            if (Mysqlcon.Execute(SQL))
                Console.WriteLine("Registro Guardado!");
            else
                Console.WriteLine("Error no se pudo guardar");
        } //end guardar
        
        public static void Eliminar(int id)
        {
            SQL = "DELETE from Clientes WHERE id=" + id;
            if (Mysqlcon.Execute(SQL))
                Console.WriteLine("Registro Eliminado!");
            
        }

        public static Cliente Buscar(int id)
        {
            Cliente ob = null;
            SQL = "Select * from clientes where id=" + id;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            if (rg.Read())
            {
                ob = new Cliente();
                ob.Id = rg.GetInt32("id");//Campo DB
                ob.Documento = rg.GetString("documento");
                ob.Nombres = rg.GetString("nombres");
                ob.Apellidos = rg.GetString("apellidos");
                ob.Direccion = rg.GetString("direccion");
                ob.Telefono = rg.GetString("telefono");
                ob.Correo = rg.GetString("correo");
            }
            rg.Close();
            return ob;
        }

        public static Cliente BuscarDocumento(string doc)
        {
            Cliente ob = null;
            SQL = "Select * from clientes where documento='" + doc + "'"; //comilla simple cuando es varchar
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            if (rg.Read())
            {
                ob = new Cliente();
                ob.Id = rg.GetInt32("id");//Campo DB
                ob.Documento = rg.GetString("documento");
                ob.Nombres = rg.GetString("nombres");
                ob.Apellidos = rg.GetString("apellidos");
                ob.Direccion = rg.GetString("direccion");
                ob.Telefono = rg.GetString("telefono");
                ob.Correo = rg.GetString("correo");
            }
            rg.Close();
            return ob;
        }

        public static void Actualizar(Cliente cl)
        {

            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");
            SQL = "update clientes set documento='" + cl.Documento + "',nombres='" + cl.Nombres + "',apellidos='" + cl.Apellidos + "',direccion='" + cl.Direccion + "',telefono='" + cl.Telefono +
                "',correo='" + cl.Correo + "',modified='" + fecha +"'"+ " Where id="+cl.Id;//colocar espacion entre comilla y where
            
            Console.WriteLine(SQL);
            if (Mysqlcon.Execute(SQL))
                Console.WriteLine("Registro Actualizado!");
            else
                Console.WriteLine("Error no se pudo Actualizar");
        } //end actualizar

        public static List<Cliente> BuscarClientesConVenta()
        {
            List<Cliente> Cliente = new List<Cliente>();
            int dato = 0;
            SQL = "SELECT c.id, c.nombres , c.apellidos FROM ventas v INNER JOIN clientes c ON v.clientes_id= c.id " +
                "order by c.Nombres ASC , c.Apellidos ASC";
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Cliente ob;
            while(rg.Read())
            {
                if (dato != rg.GetInt32("id")) // No duplicar datos
                {
                    ob = new Cliente();
                    ob.Id = rg.GetInt32("id");//campo BD
                    ob.Nombres = rg.GetString("apellidos") + " " + rg.GetString("nombres");
                    
                    Cliente.Add(ob);
                }
                dato = rg.GetInt32("id");
            }          
            rg.Close();
            return Cliente;
        }

       /* public static List<Venta> BuscarComprasUsuario(int idCliente)
        {
            List<Venta> Venta= new List<Venta>();          
            SQL = "SELECT v.id, v.total FROM ventas v INNER JOIN clientes c ON v.clientes_id= c.id where c.id=" + idCliente;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Console.WriteLine(SQL);
            Venta ob;
            while(rg.Read())
            {
                ob = new Venta();
                ob.Id = rg.GetInt32("id");
                ob.Numero = rg.GetString("id") + " - " + rg.GetString("total");
               // ob.Fecha = rg.GetString("fecha");
                Venta.Add(ob);
            }
            rg.Close();
            return Venta;
        }*/

        public static List<Cliente> BuscarClientesV(int idVenta)
        {
            List<Cliente> Cliente = new List<Cliente>();
           
            SQL = "SELECT c.id, c.nombres , c.apellidos, c.direccion, c.telefono, c.correo FROM ventas v INNER JOIN clientes c ON v.clientes_id= c.id where v.id=" + idVenta;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Cliente ob;
            while (rg.Read())
            {               
                    ob = new Cliente();
                    ob.Id = rg.GetInt32("id");//campo BD
                    ob.Nombres = rg.GetString("apellidos") + " " + rg.GetString("nombres");
                    ob.Direccion =rg.GetString("direccion");
                    ob.Telefono = rg.GetString("telefono");
                    ob.Correo = rg.GetString("correo");

                    Cliente.Add(ob);
               
            }
            rg.Close();
            return Cliente;
        }

      /*  public static List<Vendedor> BuscarVendedorDeCliente(int idVenta)
        {
            List<Vendedor> Vendedor = new List<Vendedor>();
            SQL = "SELECT vd.id, vd.nombres, vd.apellidos FROM ventas v INNER JOIN vendedores vd ON v.vendedores_id= vd.id where v.id="+idVenta;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Vendedor ob;
            while (rg.Read())
            {
                ob = new Vendedor();
                ob.Id = rg.GetInt32("id");//campo BD
                ob.Nombres = rg.GetString("nombres") + " " + rg.GetString("apellidos");
                
                Vendedor.Add(ob);

            }
            rg.Close();

            return Vendedor;
        }*/

        public static List<Producto> DetalleVentaCliente(int idVenta)
        {
            List<Producto> producto = new List<Producto>();
            SQL = "SELECT p.id, p.descripcion, p.cantidad, p.precio FROM ventas v INNER JOIN detalles dt ON dt.ventas_id= v.id " +
                "INNER JOIN productos p ON dt.productos_id= p.id where v.id="+idVenta;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Producto ob;
            while (rg.Read())
            {
                ob = new Producto();
                ob.Id = rg.GetString("id");//campo BD
                ob.Descripcion = rg.GetString("descripcion");
                ob.Cantidad = rg.GetInt32("cantidad");
                ob.Precio = rg.GetDouble("precio");
               
                producto.Add(ob);

            }
            rg.Close();
            return producto;
        }
        public static List<Venta> Buscardatos(int idventacl)
        {
            List<Venta> Venta = new List<Venta>();
            SQL = "SELECT v.id, v.total, v.fecha FROM ventas v INNER JOIN clientes c ON v.clientes_id= c.id where v.clientes_id=" + idventacl;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Console.WriteLine(SQL);
            Venta ob;
            while (rg.Read())
            {
                ob = new Venta();
                ob.Id = rg.GetInt32("id");
                ob.Fecha = rg.GetString("fecha");
                ob.Total= rg.GetDouble("total");
                ob.Numero = rg.GetString("id") + "-" + rg.GetString("total");
                // ob.Fecha = rg.GetString("fecha");
                Venta.Add(ob);
            }
            rg.Close();
            return Venta;
        }

        public static Venta BuscarDatosVenta(int idventa)
        {
            SQL = "SELECT v.id, v.total, v.fecha FROM ventas v WHERE v.id=" + idventa;
            MySqlDataReader rg = Mysqlcon.Query(SQL);
            Console.WriteLine(SQL);
            Venta ob = null;
            if (rg.Read())
            {
                ob = new Venta();
                ob.Id = rg.GetInt32("id");
                ob.Fecha = rg.GetString("fecha");
                ob.Total = rg.GetDouble("total");
                // ob.Fecha = rg.GetString("fecha");
            }
            rg.Close();
            return ob;
        }

    }//end clase

}
