<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="neptun.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="CustomerID,TerritoryID" 
                        DataNavigateUrlFormatString="http://www.test.com/tester.aspx?id={0}&amp;territory={1}" 
                        DataTextField="CustomerID" DataTextFormatString="{0}. Müşteri" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorks2019ConnectionString %>" SelectCommand="SELECT CustomerID, TerritoryID FROM Sales.Customer"></asp:SqlDataSource>
    </form>
</body>
</html>
