using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace web_parcial
{
    public class Productos
    {
        ConexionBD conectar;

        private DataTable drop_marca()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select idMarca as id,marca from marcas;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }

        public void drop_marca(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige Marca>>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_marca();
            drop.DataTextField = "marca";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        private DataTable grid_prod()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.idProducto as id,e.Producto,e.Descripcion,e.precio_costo,e.precio_venta,e.existencia,m.marca,m.idMarca from producto as e inner join marcas as m on e.idMarca = m.idMarca;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }

        public void grid_prod(GridView grid)
        {
            grid.DataSource = grid_prod();
            grid.DataBind();
        }

        public int agregar(string Producto,string Descripcion,string precio_costo,string precio_venta, string existencia,int idMarca)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into producto(Producto,Descripcion,precio_costo,precio_venta,existencia,idMarca) values('{0}','{1}','{2}','{3}','{4}','{5}');", Producto,Descripcion,precio_costo,precio_venta,existencia,idMarca);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);

            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }

        internal int modificar(int v1, string text1, string text2, string text3, TextBox txt_precio_venta, string text4, int v2)
        {
            throw new NotImplementedException();
        }

        public int modificar(int id, string Producto, string Descripcion, string precio_costo, string precio_venta, string existencia, int idMarca)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update producto set Producto='{0}',Descripcion='{1}',precio_costo='{2}',precio_venta='{3}',existencia='{4}',idMarca={5} where idProducto={6};",Producto,Descripcion,precio_costo,precio_venta,existencia,idMarca,id);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);

            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }

        public int eliminar (int id)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("delete from producto where idProducto = {0};", id);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);

            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }


    }
}