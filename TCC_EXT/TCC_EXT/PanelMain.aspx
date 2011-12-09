<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bubble Panel</title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Region="North" Split="true" Collapsible="false">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server" AutoWidth="true" AutoHeight="true">
                        <Items>
                            <ext:Button ID="Button1" runat="server" Text="Início" />
                            <ext:Button ID="Button2" runat="server" Text="Meu Portifólio">
                                <Menu>
                                    <ext:Menu ID="PanelsMenu" runat="server">
                                        <Items>
                                            <ext:Button runat="server" ID="Button3" Text="Em carteira" />
                                            <ext:MenuSeparator />
                                            <ext:Button runat="server" ID="Button4" Text="Em observação" />
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                            </ext:Button>
                            <ext:Button ID="Button5" runat="server" Text="Operações" />
                        </Items>
                    </ext:Toolbar>
                </TopBar>
            </ext:Panel>
            <ext:Window runat="server" ID="wdnFramePrincipal" MonitorResize="true" Maximized="true"
                Region="Center" Closable="false">
                <Items>
                    <ext:Panel runat="server" ID="pnlPrincipal">
                        <Items>
                            <asp:ContentPlaceHolder ID="HeadContent" runat="server">
                            </asp:ContentPlaceHolder>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Window>
        </Items>
    </ext:Viewport>
</body>
</html>
