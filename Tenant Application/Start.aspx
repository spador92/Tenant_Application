<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="Tenant_Application.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        body{
            background-color:aqua;
            text-align: center;
            background-image:"pattern.png";
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Please input number of properties you own:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxProp" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPropError" runat="server"></asp:Label>
            <br />
            <br />
            Please input the monthly rent:<br />
            <asp:TextBox ID="TextBoxRent" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblRentError" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" Text="lblGeneralError"></asp:Label>
            <br />
            <asp:Button ID="btnProp" runat="server" OnClick="btnProp_Click" Text="Enter" />
        </div>
    </form>
</body>
</html>
