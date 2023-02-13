<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="neptun.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <table>
                    <tr>
                        <td><asp:Image ImageUrl='<%# "img/" + Eval("resim")%>' runat="server" Height="100" ToolTip='<%# Eval("urunadi") %>' /></td>
                        <td><asp:Label ID="lblurunadi" runat="server" Text='<%# Eval("urunadi ") %>'></asp:Label></td>
                        <td><b><asp:Label ID="lblfiyat" runat="server" Text='<%# Eval("fiyat ") %>'></asp:Label></b></td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eticaretConnectionString %>" SelectCommand="SELECT * FROM [urun]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
