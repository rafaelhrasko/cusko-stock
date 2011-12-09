<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarteirasPnl.aspx.cs" Inherits="TCC_EXT.CarteirasPnl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var AcaoWrittenText = function (btn, text) {
            if (btn == "ok") {
                Ext.net.DirectMethods.reloadForSymbol(text);
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
                            <ext:Button ID="btnAdicionar" runat="server" Text="Adicionar Ação">
                                <DirectEvents>
                                    <Click OnEvent="adicionarAcao">
                                    </Click>
                                </DirectEvents>
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
                                            <ext:RecordField Name="id" Mapping="Acao.iCodigo" />
                                            <ext:RecordField Name="company" Mapping="Acao.StrSimbolo" />
                                            <ext:RecordField Name="price" Mapping="FValorNegociado" Type="Float" />
                                            <ext:RecordField Name="pctChange" Mapping="FPercentual" Type="Float" />
                                            <ext:RecordField Name="lastChange" Mapping="DtNegociada" Type="Date" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column Header="Ação" Width="160" DataIndex="company" />
                                <ext:Column Header="Preço" Width="75" DataIndex="price">
                                    <Renderer Format="UsMoney" />
                                </ext:Column>
                                <ext:Column Header="Pontos" Width="75" DataIndex="pctChange" />
                                <ext:Column Header="Ultima Negociação" Width="150px" DataIndex="lastChange" />
                               
                                <ext:CommandColumn Width="60">
                                    <Commands>
                                        <ext:GridCommand Icon="Delete" CommandName="Delete">
                                            <ToolTip Text="Delete" />
                                        </ext:GridCommand>
                                        <ext:CommandSeparator />
                                    </Commands>
                                </ext:CommandColumn>
                                <ext:CommandColumn Width="60">
                                    <Commands>
                                        <ext:GridCommand Icon="Computer" CommandName="precoVenda">
                                            <ToolTip Text="Sugerir Preço de Venda" />
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
                            <Command Handler="Ext.net.DirectMethods.BigSwitch(command,record.data.company);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
