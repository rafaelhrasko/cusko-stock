<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettingsCarteiraPnl.aspx.cs"
    Inherits="TCC_EXT.SettingsPnl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var saveWrittenText = function (btn, text) {
            alert('lol');
            if (btn == "ok") {
                Ext.net.DirectMethods.NovaCarteira(text);
            } else {
                alert('Cancelado');
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport runat="server" Layout="FitLayout">
        <Items>
            <ext:Panel runat="server" ID="mainPanel" Layout="FitLayout" MonitorResize="true"
                AnchorHorizontal="100%" AnchorVertical="100%">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="btnAdicionar" runat="server" Text="Adicionar Carteira">
                                <Listeners>
                                    <Click Handler="Ext.net.DirectMethods.newCarteira();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:GridPanel ID="GridPanel1" runat="server" Frame="true" StripeRows="true" Collapsible="true"
                        AnimCollapse="false" TrackMouseOver="false" AnchorHorizontal="100%" Layout="FitLayout"
                        MonitorWindowResize="true">
                        <Store>
                            <ext:Store ID="Store1" runat="server" SerializationMode="Complex">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="id" Mapping="ICodigo" />
                                            <ext:RecordField Name="company" Mapping="StrNome" />
                                            <ext:RecordField Name="price" Mapping="IQuantidadeAcoesNaCarteira" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column Header="Carteira" Width="160" DataIndex="company" />
                                <ext:Column Header="Quantidade de Ações" Width="75" DataIndex="price" />
                                <ext:CommandColumn Width="60">
                                    <Commands>
                                        <ext:GridCommand Icon="Delete" CommandName="Delete">
                                            <ToolTip Text="Delete" />
                                        </ext:GridCommand>
                                        <ext:CommandSeparator />
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="true">
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <Listeners>
                            <Command Handler="Ext.net.DirectMethods.deletarAcoes(record.data.StrNome);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
