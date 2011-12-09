<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PesquisarHistAtualizacao.aspx.cs"
    Inherits="TCC_EXT.PesquisarHistAtualizacao" %>

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
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North MarginsSummary="5 5 5 5" Collapsible="true">
                    <ext:Panel ID="Panel1" runat="server" Title="" Height="500" Padding="5" Frame="true">
                        <Content>
                        </Content>
                    </ext:Panel>
                </North>
                <Center MarginsSummary="0 5 0 5" Collapsible="true" Split="true" CollapseMode="Mini">
                    <ext:GridPanel ID="GridPanel1" runat="server" Frame="true" StripeRows="true" Collapsible="true"
                        AnimCollapse="false" TrackMouseOver="false" Width="800" Height="300">
                        <Store>
                            <ext:Store ID="Store1" runat="server" SerializationMode="Complex">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="FundosTotais" Mapping="FundosTotais" />
                                            <ext:RecordField Name="GanhoMensal" Mapping="GanhoMensal" />
                                            <ext:RecordField Name="GanhoAcumulado" Mapping="GanhoAcumulado" />
                                            <ext:RecordField Name="DataFundo" Mapping="DataFundo" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:DateColumn DataIndex="DataFundo" Header="Data" Format="d/M/y" />
                                <ext:Column DataIndex="FundosTotais" Header="Fundos Totais">
                                    <Renderer Format="UsMoney" />
                                </ext:Column>
                                <ext:Column DataIndex="GanhoMensal" Header="Ganho Mensal (%)">
                                </ext:Column>
                                <ext:Column DataIndex="GanhoAcumulado" Header="Ganho Acumulado (%)" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false">
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button runat="server" Text="Gráfico de Acompanhamento">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                    </ext:GridPanel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
