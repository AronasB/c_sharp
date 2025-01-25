<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="LD2_22.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Universitetas</title>
    <link rel="stylesheet" href="../Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Aronas Butkevičius IFD-3/2" style="text-align: center"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="2 LD_22" style="text-align: center"></asp:Label>
            <br />
            <br />
            <div class="container">
            <asp:Label ID="Label3" runat="server"></asp:Label>
            &nbsp;<asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            &nbsp;<asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox4" runat="server"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox5" runat="server"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox7" runat="server"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Neįvedėte vardo" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Neįvedėte pavardės" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ieškoti" style="height: 26px" />
            <br />
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox6" runat="server"></asp:ListBox>
            </div>
        </div>
    </form>
</body>
</html>
