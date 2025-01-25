<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LD4_22.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LD4_22</title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="Label1" runat="server" Text="Įveskite nuorodą į jūsų aplanką"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Skaityti" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Šaldytuvų spalvos"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Virdulių spalvos"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Pigiausias A+ klasės šaldytuvas"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Pigiausias A+ klasės mikrobangų krosnelė"></asp:Label>
            <br />
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Pigiausias A+ klasės virdulys"></asp:Label>
            <br />
            <asp:Table ID="Table5" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Šaldytuvų, kurių plotis nuo 52 iki 56 cm"></asp:Label>
            <br />
            <asp:Table ID="Table6" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Brangūs šaldytuvai"></asp:Label>
            <br />
            <asp:Table ID="Table7" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Brangios mikrobangų krosnelės"></asp:Label>
            <br />
            <asp:Table ID="Table8" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Brangūs virduliai"></asp:Label>
            <br />
            <asp:Table ID="Table9" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
