<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="JSON_Analyzer.Pages.Table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container well">
            <div>
                <label class="label label-info">select column</label>
                <asp:DropDownList ID="searchDropDown" runat="server"></asp:DropDownList>
                <label class="label label-info">enter search value</label>
                <asp:TextBox ID="searchTextBox" runat="server" CssClass="input "></asp:TextBox>
                <asp:Button ID="searchBtn" runat="server" CssClass="btn btn-primary" OnClick="searchBtn_Click" Text="Search" />
                <asp:Button ID="deleteBtn" runat="server" CssClass="btn btn-primary" OnClick="deleteBtn_Click" Text="Delete" />
            </div>
            <div>
                <%--<label class="label label-info">delete item index</label>--%>
                <%--<asp:TextBox ID="deleteTextBox" runat="server" CssClass="input "></asp:TextBox>--%>              
                <%--<asp:Button ID="createBtn" runat="server" CssClass="btn btn-primary" OnClick="AddBtn_Click" Text="Add item" />--%>
            </div>
        </div>
    </form>
</body>
</html>
