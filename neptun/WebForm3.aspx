<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="neptun.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BusinessEntityID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" PageSize="25">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="title" HeaderText="Title" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:CommandField DeleteText="Sil" EditText="Düzenle" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:AdventureWorks2019ConnectionString %>" 
                SelectCommand="SELECT [Title], [FirstName], [MiddleName], [LastName], [Suffix], [BusinessEntityID] FROM Person.Person" 
                DeleteCommand="DELETE FROM Person.Person WHERE BusinessEntityID=@BusinessEntityID" 
                UpdateCommand="UPDATE Person.Person SET Title=@Title, FirstName=@FirstName,  MiddleName=@MiddleName, LastName=@LastName WHERE BusinessEntityID=@BusinessEntityID"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
