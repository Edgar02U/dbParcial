using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_parcial
{
    public partial class _Default : Page
    {
        Productos productos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productos = new Productos();
                productos.drop_marca(drop_marca);
                productos.grid_prod(grid_prod);
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            productos = new Productos();
            if (productos.agregar(
                txt_producto.Text,
                txt_descripcion.Text,
                txt_precio_costo.ToString(),
                txt_precio_venta.ToString(),
                txt_existencia.Text,
                Convert.ToInt32(drop_marca.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Ingreso Exitoso";
                productos.grid_prod(grid_prod);

            }
        }

        protected void grid_prod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid_empleados.SelectedValue.ToString();
            //grid_empleados.DataKeys[indice].Values["id"].ToString();
            txt_producto.Text = grid_prod.SelectedRow.Cells[2].Text;
            txt_descripcion.Text = grid_prod.SelectedRow.Cells[3].Text;
            txt_precio_costo.Text = grid_prod.SelectedRow.Cells[4].Text;
            txt_precio_venta.Text = grid_prod.SelectedRow.Cells[5].Text;
            txt_existencia.Text = grid_prod.SelectedRow.Cells[6].Text;
            int indice = grid_prod.SelectedRow.RowIndex;
            drop_marca.SelectedValue = grid_prod.DataKeys[indice].Values["idMarca"].ToString();

            btn_modificar.Visible = true;
        }

        protected void grid_prod_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            productos = new Productos();
            if (productos.eliminar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lbl_mensaje.Text = "Eliminacion Exitoso";
                productos.grid_prod(grid_prod);
                btn_modificar.Visible = false;

            }


        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {

            productos = new Productos();
            if (productos.modificar(
                Convert.ToInt32(grid_prod.SelectedValue),
                txt_producto.Text,
                txt_descripcion.Text,
                txt_precio_costo.ToString(),
                txt_precio_venta.ToString(),
                txt_existencia.Text,
                Convert.ToInt32(drop_marca.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Modificacion Exitoso";
                productos.grid_prod(grid_prod);
                btn_modificar.Visible = false;

            }


        }
    }
}