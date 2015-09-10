<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aa.aspx.cs" Inherits="TaskWeb.aa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtContent" runat="server" Height="80px" TextMode="MultiLine" Width="95%"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtp" runat="server" Width="165px" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    
    </div>
        <asp:GridView ID="gvData" runat="server" AllowPaging="True" Width="95%" DataSourceID="dsSQL">
        </asp:GridView>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:SqlDataSource ID="dsSQL" runat="server" ConnectionString="<%$ ConnectionStrings:DBString %>" SelectCommand="SELECT * FROM [tbTask]"></asp:SqlDataSource>
    </form>
</body>
</html>
