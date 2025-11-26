<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Proyecto2WebForms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblTitulo" runat="server" Text="Web API Calculadora"></asp:Label>
        <p>
            <asp:Label ID="lblSubtitulo" runat="server" Text="Datos a exponer"></asp:Label>
        </p>
        <asp:Button ID="btnSumas" runat="server" Text="Sumas" OnClick="btnSumas_Click" />
        <asp:Button ID="btnRestas" runat="server" Text="Restas" OnClick="btnRestas_Click"/>
        <asp:Button ID="btnMultiplicaciones" runat="server" Text="Multiplicaciones" OnClick="btnMultiplicaciones_Click" />
        <asp:Button ID="btnDivisiones" runat="server" Text="Divisiones" OnClick="btnDivisiones_Click"/>
        <asp:Button ID="btnTodos" runat="server" Text="Todos " OnClick="btnTodos_Click" />

        <p>
        <asp:ListBox ID="ltbResultados" runat="server"></asp:ListBox>
        </p>
    </form>
</body>
</html>
