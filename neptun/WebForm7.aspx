<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="neptun.WebForm7" %>

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
                            <td rowspan="2"><asp:Image ImageUrl='<%# "img/" + Eval("MusteriID") + ".jpg"%>' runat="server" Height="100" /></td>
                            <td><asp:Label ID="lblurunadi" runat="server" Text='<%# Eval("unvan") %>'>&nbsp;</asp:Label><asp:Label ID="Label1" runat="server" Text='<%# Eval("MusteriAd") %>'></asp:Label>&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("MusteriSoyad") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblfiyat" runat="server" Text='<%# Eval("MusteriDT") %>'></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eticaretConnectionString %>" SelectCommand="SELECT * FROM [Musteriler] INNER JOIN Unvanlar ON UnvanID=MusteriUnvan"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
