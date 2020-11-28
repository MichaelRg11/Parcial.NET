<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Appwebfacturacion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cliente consumidor de ws facturacion </h1>
        <p>
            <table class="nav-justified" style="width: 89%; height: 170px">
                <tr>
                    <td style="width: 180px; height: 30px;">ID</td>
                    <td style="height: 30px">
                        <asp:TextBox ID="txtid" runat="server" Width="123px" Enabled="False" ></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="cbxclientes" runat="server" Width="206px" AutoPostBack="true" OnSelectedIndexChanged="cbxclientes_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 180px">Documento</td>
                    <td>
                        <asp:TextBox ID="txtdocumento" runat="server" Width="302px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 180px">Nombres</td>
                    <td>
                        <asp:TextBox ID="txtnombres" runat="server" Width="299px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 180px">Direccion</td>
                    <td>
                        <asp:TextBox ID="txtdireccion" runat="server" Width="298px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 180px">Telefono</td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" Width="298px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 180px">Correo</td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server" Width="297px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
               

            </table>
             &nbsp;&nbsp;&nbsp;<table class="nav-justified" style="width: 89%; height: 93px">
                <tr>
                    <td style="width: 180px; height: 7px;">Ventas</td>
                    <td style="height: 7px">
                        <asp:DropDownList ID="cbxventa" runat="server" Width="284px" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" Text="Ok" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 180px; height: 29px;">Fecha</td>
                    <td style="height: 29px">
                        <asp:TextBox ID="txtfecha" runat="server" Width="276px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 180px; height: 28px;">Total</td>
                    <td style="height: 28px">
                        <asp:TextBox ID="txttotal" runat="server" Width="274px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                               

            </table>
             <h1>Detalle de la venta seleccionada</h1>
        <p>
                    <asp:GridView ID="dtgListadoCliente" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1018px">
                    </asp:GridView>
    </div>

    <div class="row">
        <div class="col-md-4">

        </div>
    </div>

</asp:Content>
