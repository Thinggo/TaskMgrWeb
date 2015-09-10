<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bb.aspx.cs" Inherits="TaskWeb.bb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="/ashx/user.ashx?action=UploadImage" enctype="multipart/form-data">
    <div>
        <input name="userName" type="text" value="admin" />
        <input name="image_head_file" type="file" /></div>
        <input id="Submit1" type="submit" value="upload" />
    </form>

</body>
</html>
