<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Najava.aspx.cs" Inherits="Najava" Title="Untitled Page" ResponseEncoding="UTF-8"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body1" Runat="Server">
    <div id="left" align="center">
    <div id="booking" align="center" dir="ltr">
          <h2>Најава</h2>
         <div>
             <table align="center" cellpadding="2" class="style1">
                 <tr>
                     <td>
                         Корисничко име</td>
                     <td>
                         <asp:TextBox ID="txtKorisnik" runat="server"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ControlToValidate="txtKorisnik" ErrorMessage="Внесете корисничко име!"></asp:RequiredFieldValidator>
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
                     <td colspan="2">
                         <asp:Label ID="lblPoraka" runat="server"></asp:Label>
                     </td>
                    
                     <td>
                         <asp:Button ID="btnVlez" runat="server" onclick="btnVlez_Click" Text="Влез" 
                             Width="82px" />
                     </td>
                    
                 </tr>
             </table>
         </div>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer1" Runat="Server">
</asp:Content>

