<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="GraficoTeste.aspx.cs" Inherits="TCC_EXT.GraficoTeste" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="Chart1" runat="server">
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
            </Legends>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
