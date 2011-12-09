<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UltimasNegociacoes.aspx.cs"
    Inherits="TCC_EXT.UltimasNegociacoes" %>

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
                    <ext:Panel ID="Panel1" runat="server" Title="" Height="100" Padding="5" Frame="true">
                        <Content>
                        </Content>
                    </ext:Panel>
                </North>
                <Center MarginsSummary="0 5 0 5" Collapsible="true" Split="true" CollapseMode="Mini">
                    <ext:GridPanel ID="GridPanel1" runat="server" Frame="true" StripeRows="true" Collapsible="true"
                        AnimCollapse="false" TrackMouseOver="false" Width="800" Height="450">
                        <Store>
                            <ext:Store ID="Store1" runat="server" SerializationMode="Complex">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="Simbolo" Mapping="Acao.StrSimbolo" />
                                            <ext:RecordField Name="Empresa" Mapping="Empresa.strNome" />
                                            <ext:RecordField Name="Preco" Mapping="FValorNegociado" Type="Float" />
                                            <ext:RecordField Name="lastChange" Mapping="DtNegociada" Type="Date" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column Header="Simbolo" Width="160" DataIndex="company" />
                                <ext:Column Header="Empresa" Width="200" DataIndex="Empresa" />
                                <ext:Column Header="Preço" Width="75" DataIndex="price">
                                    <Renderer Format="UsMoney" />
                                </ext:Column>
                                <ext:Column Header="Pontos" Width="75" DataIndex="pctChange" />
                                <ext:DateColumn Header="Ultima Negociação" Width="85" DataIndex="lastChange" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false">
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnAdicionar" runat="server" Text="Adicionar Ação">
                                    </ext:Button>
                                    <ext:Button ID="btnDeletar" runat="server" Text="Deletar Ações">
                                    </ext:Button>
                                    <ext:Button ID="btnComparar" runat="server" Text="Comparar Ações">
                                    </ext:Button>
                                    <ext:Button ID="btnSalvar" runat="server" Text="Salvar Carteira">
                                        <DirectEvents>
                                            <Click OnEvent="salvarCarteira">
                                            </Click>
                                        </DirectEvents>
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
