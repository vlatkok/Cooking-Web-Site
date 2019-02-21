<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registracija.aspx.cs" Inherits="Registracija" Title="Untitled Page" ResponseEncoding="UTF-8"%>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body1" Runat="Server">
    <div id="left" align="center">
            <div id="booking" align="center" dir="ltr">
          <h2>Регистрација</h2>
         <div>
             <table align="center" cellpadding="2" class="style1">
                 <tr>
                     <td>
                         Корисничко име</td>
                     <td>
                         <asp:TextBox ID="txtKIme" runat="server"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ControlToValidate="txtKIme" ErrorMessage="Внесете корисничко име!"></asp:RequiredFieldValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Лозинка</td>
                     <td>
                         <asp:TextBox ID="txtLozinka" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                             ControlToValidate="txtLozinka" ErrorMessage="Внесете лозинка!"></asp:RequiredFieldValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Повтори лозинка</td>
                     <td>
                         <asp:TextBox ID="txtLozinka2" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     <td>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" 
                             ControlToCompare="txtLozinka" ControlToValidate="txtLozinka2" 
                             ErrorMessage="Погрешна лозинка!"></asp:CompareValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Име</td>
                     <td>
                         <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                             ControlToValidate="txtIme" ErrorMessage="Внесете го вашето име!"></asp:RequiredFieldValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Презиме</td>
                     <td>
                         <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                             ControlToValidate="txtPrezime" ErrorMessage="Внесете го вашето презиме!"></asp:RequiredFieldValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Email</td>
                     <td>
                         <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                             ControlToValidate="txtEmail" ErrorMessage="Внесете email адреса!"></asp:RequiredFieldValidator>
                         <br />
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                             ControlToValidate="txtEmail" ErrorMessage="Внесете правилна email адреса!" 
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Label ID="lblErrorKIme" runat="server"></asp:Label>
                         <br />
                         <asp:Label ID="lblErrorEmail" runat="server"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblPoraka" runat="server"></asp:Label>
                     </td>
                     <td>
                         <asp:Button ID="btnRegistrirajMe" runat="server" 
                             onclick="btnRegistrirajMe_Click" Text="Регистрирај ме" />
                     </td>
                 </tr>
             </table>
         </div>
        </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer1" Runat="Server">
</asp:Content>

