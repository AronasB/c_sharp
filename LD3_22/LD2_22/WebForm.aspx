<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="LD2_22.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Universitetas</title>
    <link rel="stylesheet" href="../StylesSheet.css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Aronas Butkevičius IFD-3/2" style="text-align: center"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="2 LD_22" style="text-align: center"></asp:Label>
            <br />
            <br />
            <div class="container">
                <div class ="file-upload-container">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="217px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </div>
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
                <asp:Table ID="Table1" runat="server">
                </asp:Table>
                <br />
                <asp:Label ID="Label4" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Table ID="Table2" runat="server">
                </asp:Table>
                <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <br />
                <asp:Table ID="Table3" runat="server">
                </asp:Table>
            <br />
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />
            <br />
                <asp:Table ID="Table4" runat="server">
                </asp:Table>
            <br />
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <br />
            <br />
                <asp:Table ID="Table5" runat="server">
                </asp:Table>
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
                <br />
                <asp:Table ID="Table6" runat="server">
                </asp:Table>
            </div>
        </div>
    </form>
</body>
</html>
