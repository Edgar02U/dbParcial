<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_parcial._Default"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label ID="lbl_producto" runat="server" CssClass="badge" Text="Producto"></asp:Label>
    <asp:TextBox ID="txt_producto" runat="server" CssClass="form-control"></asp:TextBox>

    <asp:Label ID="lbl_descripcion" runat="server" CssClass="badge" Text="Descripcion"></asp:Label>
    <asp:TextBox ID="txt_descripcion" runat="server" CssClass="form-control"></asp:TextBox>

    <asp:Label ID="lbl_precio_costo" runat="server" CssClass="badge" TextMode="Precio Costo"></asp:Label>
    <asp:TextBox ID="txt_precio_costo" runat="server" CssClass="form-control"></asp:TextBox>

    <asp:Label ID="lbl_precio_venta" runat="server" CssClass="badge" Textmode="Precio Venta"></asp:Label>
    <asp:TextBox ID="txt_precio_venta" runat="server" CssClass="form-control"></asp:TextBox>
    
    <asp:Label ID="lbl_esxistencia" runat="server" CssClass="badge" Textmode="Existencia"></asp:Label>
    <asp:TextBox ID="txt_existencia" runat="server" CssClass="form-control"></asp:TextBox>

    

    <asp:Label ID="lbl_marca" runat="server" CssClass="badge" Text="Marca"></asp:Label>
    <asp:DropDownList ID="drop_marca" runat="server" CssClass="form-control"></asp:DropDownList>

    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-info btn-lg" OnClick="btn_agregar_Click" />
    <asp:Button ID="btn_modificar" runat="server" OnClick="btn_modificar_Click" Text="Modificar" CssClass="btn btn-success btn-lg" Visible="False" />
    <asp:Label ID="lbl_mensaje" runat="server" CssClass="alert-info"></asp:Label>
    <asp:GridView ID="grid_prod" runat="server" AutoGenerateColumns="False" CssClass="table-condensed" DataKeyNames="idProducto,idMarca" OnRowDeleting="grid_prod_RowDeleting" OnSelectedIndexChanged="grid_prod_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Ver" ShowSelectButton="True" ControlStyle-CssClass="btn btn-info" >
<ControlStyle CssClass="btn btn-info"></ControlStyle>
            </asp:CommandField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea Eliminar?'))return false"  />
                </ItemTemplate>
                <ControlStyle CssClass="btn btn-danger" />
            </asp:TemplateField>
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="precio_costo" HeaderText="Precio Costo" />
            <asp:BoundField DataField="precio_venta" HeaderText="Precio Venta" />
            <asp:BoundField DataField="existencia" HeaderText="Existencia" />         
            <asp:BoundField DataField="idMarca" HeaderText="Marca" />
        </Columns>
    </asp:GridView>

</asp:Content>
