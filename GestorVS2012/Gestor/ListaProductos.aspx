<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListaProductos.aspx.vb" Inherits="GestorVS2012.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link href ="../Content/bootstrap.css" rel="stylesheet" />--%>
    <style type="text/css">
        .style8 {
            width: 377px;
            text-align: right;
            color: white;
            height: 208px;
        }

        .style9 {
            width: 287px;
            height: 208px;
        }

        .style10 {
            width: 287px;
            height: 41px;
        }

        .style11 {
            width: 287px;
            height: 42px;
        }

        .style12 {
            width: 380px;
            text-align: right;
            color: White;
            height: 41px;
        }

        .style13 {
            width: 377px;
            text-align: right;
            color: White;
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="margin-left: 10px; margin-right:4px;">
        <div class="frmBase2">
            <div id="indicador" style="margin-right: auto; text-align: right;">
                <asp:Label ID="menu" runat="server" Text="Lista de Articulos" Font-Bold="True" Font-Size="Medium" ForeColor="Maroon">
                </asp:Label>

            </div>
            <%-- class "col-sm-4 col-md-3" la sig tenìa colx ;--%>
            <div style="text-align: center; top: 0px; left: 0px;">
                <asp:Label ID="LblNombEmp" runat="server"
                    Text="DEMO EMPRESA S.A C.V." Font-Size="Medium" ForeColor="#000066"></asp:Label>
            </div>
        </div>
        <%--class ="col-sm-4 col-md-3"--%>
        <div style="text-align: right">
            Buscar :<asp:TextBox ID="TextBox1" Style="color: black" runat="server"
                AutoPostBack="True" /><br />
            <asp:Label ID="LblResult" runat="server" Font-Bold="True" ForeColor="#CC0000"
                Text="cargados" Visible="False"></asp:Label><br />
            <asp:GridView ID="GridView1" runat="server" Height="77px"
                AllowPaging="True" DataKeyNames="codigo"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging"
                Width="100%" CellPadding="4" BackColor="White" BorderColor="#3366CC" CellSpacing="10" GridLines="Vertical">
                <Columns> <%--Width="386px"  cellpadin..  --%>
                    <asp:CommandField SelectText="Ver detalle" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" BorderStyle="Solid" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>

        </div>
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px"
                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                CellPadding="3" GridLines="Horizontal" DataKeyNames="codigo" OnItemUpdated="DetailsView1_ItemUpdated">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <Fields>
                    <asp:CommandField ShowEditButton="True" />
                </Fields>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            </asp:DetailsView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
