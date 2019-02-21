<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dodadi.aspx.cs" Inherits="Dodadi" Title="Untitled Page" ResponseEncoding="UTF-8"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        text-align: center;
        font-weight: bold;
        color: #FF0000;
            font-family: Verdana;
            font-size: medium;
        }
    .style4
    {
        text-align: right;
        width: 158px;
    }
</style>
<script language="javascript" type="text/javascript">
// <!CDATA[

function FileField_onclick() {

}

// ]]>
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body1" Runat="Server">
    <asp:Panel ID="pnlDodadi" runat="server" BorderColor="#CC3300" 
    BorderStyle="Solid" BorderWidth="1px" Width="620px">
    <table class="style1" align="center">
        <tr>
            <td bgcolor="Maroon" class="style5" colspan="2" >
                Додади рецепт</td>
        </tr>
        <tr>
            <td class="style4" bgcolor="#990000">
                Назив на рецептот:</td>
            <td style="text-align: right">
                <asp:TextBox ID="txtNazivRecept" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4" bgcolor="#990000">
                Текст:</td>
            <td style="text-align: right">
                <asp:TextBox ID="txtRecept" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4" bgcolor="#990000">
                Тип:</td>
            <td style="text-align: right">
                <asp:DropDownList ID="DDlistTip" runat="server">
                    <asp:ListItem Value="salati">Салати</asp:ListItem>
                    <asp:ListItem Value="predjadenja">Предјадење</asp:ListItem>
                    <asp:ListItem Value="glavniJadenja">Главно јадење</asp:ListItem>
                    <asp:ListItem Value="deserti">Десерти</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4" bgcolor="#990000">
                Слика:</td>
            <td style="text-align: right">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Panel ID="pnlSlikaUpload" runat="server" BackColor="Maroon" 
                    Visible="False">
                    име:
                    <asp:Label ID="lblSlikaFileName" runat="server" Text="filename"></asp:Label>
                    &nbsp; големина:
                    <asp:Label ID="lblSlikaFileSize" runat="server" Text="filesize"></asp:Label>
                    &nbsp;содржина:<asp:Label ID="lblSlikaFileContent" runat="server" Text="filecontent"></asp:Label>
                    &nbsp;локација:<asp:Label ID="lblAdresaSlika" runat="server" Text="Label"></asp:Label>
                    &nbsp;<br />
                    <asp:Label ID="lblSlikaPoraka" runat="server"></asp:Label>
                    &nbsp;</asp:Panel>
                <input ID="FileField" runat="server" onclick="return FileField_onclick()" 
                    size="60" type="File" /><asp:Button ID="btnUploadSlika" runat="server" 
                    Font-Size="Small" onclick="btnUploadSlika_Click" style="margin-left: 0px" 
                    Text="Аплоадирај..." Width="124px" />
            </td>
        </tr>
        <tr>
            <td class="style4" bgcolor="#990000">
                Видео:</td>
            <td style="text-align: right">
                <br />
                <asp:Panel ID="pnlSlikaUpload0" runat="server" BackColor="Maroon" 
                    Visible="False">
                    име:
                    <asp:Label ID="lblSlikaFileName0" runat="server" Text="filename"></asp:Label>
                    &nbsp; големина:
                    <asp:Label ID="lblSlikaFileSize0" runat="server" Text="filesize"></asp:Label>
                    &nbsp;содржина:<asp:Label ID="lblSlikaFileContent0" runat="server" 
                        Text="filecontent"></asp:Label>
                    &nbsp;локација:<asp:Label ID="lblAdresaVideo" runat="server" Text="Label"></asp:Label>
                    &nbsp;<br />
                    <asp:Label ID="lblSlikaPoraka0" runat="server"></asp:Label>
                    &nbsp;</asp:Panel>
                <input ID="FileField1" runat="server" size="60" type="File" /><asp:Button 
                    ID="btnUploadVideo" runat="server" onclick="btnUploadVideo_Click" 
                    style="height: 26px" Text="Аплоадирај..." />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td style="text-align: right">
                
                <asp:Button ID="btnDodadiRecept" runat="server" onclick="btnDodadiRecept_Click" 
                    Text="Додади Рецепт" Width="123px" />
                
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer1" Runat="Server">
    <asp:Label ID="lblVideoAdresa" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblUploadPoraka" runat="server" Font-Bold="True" 
        Font-Size="Medium"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;  
</asp:Content>

