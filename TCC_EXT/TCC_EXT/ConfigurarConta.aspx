<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigurarConta.aspx.cs"
    Inherits="TCC_EXT.ConfigurarConta" %>

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
            <ext:Panel ID="GridPanel1" runat="server" Frame="true" StripeRows="true" Collapsible="true"
                AnimCollapse="false" TrackMouseOver="false" Width="800" Height="450">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="btnAdicionar" runat="server" Text="Adicionar Ação">
                            </ext:Button>
                            <ext:Button ID="btnDeletar" runat="server" Text="Deletar Ações">
                            </ext:Button>
                            <ext:Button ID="btnComparar" runat="server" Text="Comparar Ações">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:BorderLayout ID="BorderLayout1" runat="server">
                        <North>
                            <ext:Panel runat="server">
                            </ext:Panel>
                        </North>
                        <Center>
                            <ext:GridPanel runat="server" Title="Histórico de Adições">
                            </ext:GridPanel>
                        </Center>
                        <South>
                            <ext:Panel ID="Panel1" runat="server">
                            </ext:Panel>
                        </South>
                    </ext:BorderLayout>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
