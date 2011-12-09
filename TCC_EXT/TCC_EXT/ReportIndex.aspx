<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportIndex.aspx.cs" Inherits="TCC_EXT.ReportIndex" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        var addTab = function (tabPanel, id, url) {
            var tab = tabPanel.getComponent(id);
            if (!tab) {
                tab = tabPanel.add({
                    id: id,
                    title: 'Relatório',
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
    <ext:Viewport ID="ViewPort1" runat="server" Layout="Fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <West Split="true" CollapseMode="Mini" MarginsSummary="4 0 4 4">
                    <ext:Panel ID="Panel1" runat="server" Width="225">
                        <Items>
                            <ext:TreePanel ID="treeMenu" runat="server" Border="false" Width="300" Height="450"
                                AutoScroll="true">
                                <Root>
                                    <ext:TreeNode Text="Reports">
                                        <Nodes>
                                            <ext:TreeNode Text="Sugerir Ações">
                                                <Listeners>
                                                    <Click Handler="addTab(#{DoodTp}, 'idGgl', 'PesquisarHistAtualizacao.aspx');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Root>
                                <Listeners>
                                </Listeners>
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
