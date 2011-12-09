<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdicionarCarteira.aspx.cs"
    Inherits="TCC_EXT.AdicionarCarteira" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport runat="server" Layout="FitLayout">
        <Items>
            <ext:Panel runat="server" Layout="FormLayout">
                <Items>
                    <ext:TextField runat="server" ID="txtNome" FieldLabel="Nome da Carteira" AnchorHorizontal="100%">
                    </ext:TextField>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
