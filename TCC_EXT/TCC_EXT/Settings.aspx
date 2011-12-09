<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="TCC_EXT.Settings" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var addTab = function (tabPanel, title, id, url) {
            var tab = tabPanel.getComponent(id);
            if (!tab) {
                tab = tabPanel.add({
                    id: id,
                    title: title,
                    closable: true,
                    autoLoad: {
                        showMask: true,
                        url: url,
                        mode: "iframe",
                        maskMsg: "Carregando..."
                    }
                });
                tab.on("activate", function () {
                    var item = MenuPanel1.menu.items.get(id + "_item");
                    if (item) {
                        MenuPanel1.setSelection(item);
                    }
                }, this);
            }
            tabPanel.setActiveTab(tab);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport runat="server" Layout="FitLayout">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <West Split="true" CollapseMode="Mini" MarginsSummary="4 0 4 4">
                    <ext:Panel ID="Panel1" runat="server" Width="225">
                        <Items>
                            <ext:TreePanel ID="treeMenu" runat="server" Border="false" Width="300" Height="450"
                                AutoScroll="true">
                                <Root>
                                    <ext:TreeNode Text="Configurações" Icon="MoneyAdd">
                                        <Nodes>
                                            <ext:TreeNode Text="Controlar Carteiras" Icon="MoneyAdd">
                                                <Listeners>
                                                    <Click Handler="addTab(#{DoodTp}, 'Controlar Carteiras', 'cartControl', 'SettingsCarteiraPnl.aspx');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Registrar Negociação" Icon="MoneyAdd">
                                                <Listeners>
                                                    <Click Handler="addTab(#{DoodTp}, 'Registrar Negociação', 'negControl', 'SettingsNegociacaoPnl.aspx');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Root>
                            </ext:TreePanel>
                        </Items>
                    </ext:Panel>
                </West>
                <Center MarginsSummary="4 4 4 0">
                    <ext:TabPanel ID="DoodTp" runat="server" EnableTabScroll="true">
                        <Plugins>
                            <ext:TabCloseMenu ID="TabCloseMenu1" runat="server" />
                            <ext:TabScrollerMenu ID="TabScrollerMenu1" runat="server" />
                        </Plugins>
                    </ext:TabPanel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
