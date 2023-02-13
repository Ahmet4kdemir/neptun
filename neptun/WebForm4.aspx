<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="neptun.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MusteriID" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="MusteriID" HeaderText="MusteriID" ReadOnly="True" SortExpression="MusteriID" />
                    <asp:BoundField DataField="Unvan" HeaderText="Unvan" SortExpression="Unvan" />
                    <asp:BoundField DataField="MusteriAd" HeaderText="MusteriAd" SortExpression="MusteriAd" />
                    <asp:BoundField DataField="MusteriSoyad" HeaderText="MusteriSoyad" SortExpression="MusteriSoyad" />
                    <asp:CheckBoxField DataField="MusteriCinsiyet" HeaderText="Kadın" SortExpression="MusteriCinsiyet" />
                    <asp:BoundField DataField="MusteriDT" HeaderText="MusteriDT" SortExpression="MusteriDT" />
                    <asp:CommandField DeleteText="Sil" EditText="Düzenle" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" ButtonType="Button" CancelText="İptal" InsertText="Ekle" NewText="Yeni" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eticaretConnectionString %>" 
                DeleteCommand="DELETE FROM Musteriler WHERE MusteriID=@MusteriID" 
                SelectCommand="SELECT MusteriID, Unvan, MusteriAd, MusteriSoyad, MusteriCinsiyet, MusteriDT FROM Musteriler INNER JOIN Unvanlar ON MusteriUnvan=UnvanID" 
                UpdateCommand="UPDATE Musteriler SET MusteriAd=@MusteriAd,MusteriSoyad=@MusteriSoyad, MusteriCinsiyet = @MusteriCinsiyet, MusteriDT = @MusteriDT WHERE MusteriID=@MusteriID"></asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="UnvanID" DataSourceID="SqlDataSource2" OnSelectedIndexChanging="GridView2_SelectedIndexChanging">
                <Columns>
                    <asp:BoundField DataField="UnvanID" HeaderText="UnvanID" ReadOnly="True" SortExpression="UnvanID" />
                    <asp:BoundField DataField="Unvan" HeaderText="Unvan" SortExpression="Unvan" />
                    <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertVisible="False" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eticaretConnectionString %>" DeleteCommand="DELETE FROM unvanlar WHERE UnvanID=@UnvanID" SelectCommand="SELECT [UnvanID], [Unvan] FROM [Unvanlar]" UpdateCommand="UPDATE unvanlar SET unvan=@unvan WHERE unvanID=@unvanID"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
