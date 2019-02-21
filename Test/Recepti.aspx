<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recepti.aspx.cs" Inherits="Recepti" Title="Рецепти..." ResponseEncoding="UTF-8"%>

<%@ Register assembly="ASPNetVideo.NET3" namespace="ASPNetVideo" tagprefix="ASPNetVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 305px;
        }
        .style7
        {
            width: 529px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body1" Runat="Server">
    <div id="body" align="center">
        <asp:GridView ID="gvRecepti" runat="server" Width="637px" 
        CellPadding="4" AllowPaging="True" AutoGenerateColumns="False" 
            ForeColor="#333333" 
            onselectedindexchanged="gvRecepti_SelectedIndexChanged" GridLines="None" 
            DataKeyNames="ID" onpageindexchanging="gvRecepti_PageIndexChanging">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" 
                    HeaderText="Одбери" SelectText="Одбери" >
                    <ItemStyle BackColor="#7C0000" />
                </asp:CommandField>
                <asp:BoundField DataField="ID" HeaderText="ИД" />
                <asp:BoundField DataField="Naslov" HeaderText="Назив" />
                <asp:BoundField DataField="KorisnickoIme" HeaderText="Од:" />
                <asp:BoundField DataField="Datum" HeaderText="Датум" />
            </Columns>
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="#FFCC66" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Label ID="lblTest" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
    <asp:Label ID="lblPoraka" runat="server"></asp:Label>
    
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer1" Runat="Server">
    <div>
    <asp:Panel ID="Panel1" runat="server">
        <table align="center" class="style1">
            <tr>
                <td class="style6" style="text-align: left" valign="top">
                    <asp:Label ID="lblNaslov" runat="server" EnableTheming="True" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                    <br />
                    <asp:Image ID="Image1" runat="server" BorderColor="#CC0000" BorderStyle="Solid" 
                        BorderWidth="1px" Height="168px" ImageUrl="~/images/logo.jpg" Width="212px" />
                    <br />
                    Датум:<asp:Label ID="lblDatum" runat="server" Font-Bold="True" ForeColor="#993300"></asp:Label>
                    <br />
                    Од:<asp:Label ID="lblAploader" runat="server" Font-Bold="True" 
                        ForeColor="#CCFFFF"></asp:Label>
                </td>
                <td align="right" bgcolor="#5E0002" style="text-align: left" valign="top" 
                    class="style7">
                    <asp:TextBox ID="txtRecept" runat="server" BackColor="#990000" 
                        BorderColor="#FF3300" BorderStyle="Solid" BorderWidth="1px" ForeColor="#F4C389" 
                        Height="355px" ReadOnly="True" TextMode="MultiLine" Width="525px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center" bgcolor="#990000">
                    <ASPNetVideo:WindowsMedia ID="WindowsMedia1" runat="server" AutoPlay="False" 
                        Alignment="Center">
                    </ASPNetVideo:WindowsMedia>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <br />
                    <asp:Panel ID="PanelKomentar" runat="server">
                        &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BackColor="Yellow" 
                            ForeColor="#CC0000" ReadOnly="True" Width="168px">Остави коментар :</asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server" BackColor="Yellow" ForeColor="Red" 
                            ReadOnly="True" Width="164px">Внеси коментар долу</asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="txtKomentarot" runat="server" Height="72px" 
                            TextMode="MultiLine" Width="260px"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                    <asp:Button ID="Button1" runat="server" 
                        onclick="Button1_Click" Text="Исчисти го полето" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnZacuvajKomentar" runat="server" 
                            onclick="btnZacuvajKomentar_Click" Text="Објави го коментарот" />
                    <asp:Label ID="lblPorakaKomentar" runat="server"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    
                    </asp:Panel>
                    <asp:ListBox ID="lstListaSoKomentari" runat="server" Enabled="False" 
                        ForeColor="#003399" Height="251px" Width="617px"></asp:ListBox>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>

