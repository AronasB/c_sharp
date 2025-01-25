<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="LD1_22.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="Aronas Butkevičius, IFD-3/2"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="LD_22. Kelias tarp vietovių."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Pradiniai duomenys"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" Height="169px" style="margin-right: 0px" Width="259px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
            </asp:Table>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Rezultatai"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table2" runat="server" Height="204px" Width="259px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
            </asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
