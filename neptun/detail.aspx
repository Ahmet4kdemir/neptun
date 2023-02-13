<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="neptun.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>ID</td>
                    <td>:</td>
                    <td><asp:DropDownList ID="ddlID" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Telefon Tipi</td>
                    <td>:</td>
                    <td><asp:DropDownList ID="ddlPType" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Telefon Numarası</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Tarih</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click" /></td>
                    <td><asp:Button ID="Button2" runat="server" Text="Geri" OnClick="Button2_Click" /></td>
                    <td>
                        <asp:Label ID="lblMesaj" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
