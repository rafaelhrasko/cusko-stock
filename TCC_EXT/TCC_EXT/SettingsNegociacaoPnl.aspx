<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettingsNegociacaoPnl.aspx.cs"
    Inherits="TCC_EXT.SettingsNegociacaoPnl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        var addRecord = function (form, grid) {
            alert('lol');
            grid.insertRecord(0, form.getForm().getFieldValues(false, "dataIndex"));
            form.getForm().reset();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Store ID="Store2" runat="server" AutoSave="true" ShowWarningOnFailure="false"
        OnBeforeStoreChanged="HandleChanges" SkipIdForNewRecords="false" RefreshAfterSaving="None">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="id" Mapping="Acao.iCodigo" />
                    <ext:RecordField Name="company" Mapping="Acao.StrSimbolo" />
                    <ext:RecordField Name="price" Mapping="FValorNegociado" Type="Float" />
                    <ext:RecordField Name="pctChange" Mapping="FPercentual" Type="Float" />
                    <ext:RecordField Name="lastChange" Mapping="DtNegociada" Type="Date" />
                    <ext:RecordField Name="iQuantidade" Mapping="Acao.INegociacoes" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Exception Handler="
                    Ext.net.Notification.show({
                        iconCls    : 'icon-exclamation', 
                        html       : e.message, 
                        title      : 'EXCEPTION', 
                        autoScroll : true, 
                        hideDelay  : 5000, 
                        width      : 300, 
                        height     : 200
                    });" />
            <BeforeSave Handler="var valid = true; this.each(function(r){if(r.dirty && !r.isValid()){valid=false;}}); return valid;" />
        </Listeners>
    </ext:Store>
    <ext:Viewport runat="server" Layout="FitLayout">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North MarginsSummary="5 5 5 5" Collapsible="true">
                    <ext:Panel ID="Panel1" runat="server" Title="" Height="220" Padding="5" Frame="true">
                        <Items>
                            <ext:FormPanel ID="formMovimentacaoes" runat="server" Icon="User" Frame="true" LabelAlign="Right"
                                Title="Form de Inclusão de Negocioações" AnchorHorizontal="100%">
                                <Items>
                                    <ext:TextField ID="txtSimbolo" runat="server" FieldLabel="Símbolo" DataIndex="company"
                                        AllowBlank="false" AnchorHorizontal="100%" />
                                    <ext:TextField ID="txtData" runat="server" FieldLabel="Data" DataIndex="lastChange"
                                        AllowBlank="false" AnchorHorizontal="100%" />
                                    <ext:TextField ID="price" runat="server" FieldLabel="Valor Negociado" DataIndex="Last"
                                        AllowBlank="false" AnchorHorizontal="100%" />
                                    <ext:TextField ID="txtQuantidade" runat="server" FieldLabel="Quantidade" DataIndex="iQuantidade"
                                        AnchorHorizontal="100%" />
                                </Items>
                                <Buttons>
                                    <ext:Button ID="Button3" runat="server" Text="Inserir" Icon="Disk">
                                        <Listeners>
                                            <Click Handler="addRecord(#{formMovimentacaoes}, #{GridPanel1});" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="Button4" runat="server" Text="Reset">
                                        <Listeners>
                                            <Click Handler="#{formMovimentacaoes}.getForm().reset();" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:FormPanel>
                        </Items>
                    </ext:Panel>
                </North>
                <Center MarginsSummary="0 5 0 5" Collapsible="true" Split="true" CollapseMode="Mini">
                    <ext:GridPanel ID="GridPanel1" runat="server" Frame="true" StripeRows="true" Collapsible="true"
                        AnimCollapse="false" TrackMouseOver="false" Width="800" Height="450" StoreID="Store2">
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column Header="Ação" Width="160" DataIndex="company" />
                                <ext:Column Header="Preço" Width="75" DataIndex="price">
                                    <Renderer Format="UsMoney" />
                                </ext:Column>
                                <ext:Column Header="Data da Negociação" Width="150px" DataIndex="lastChange" />
                                <ext:Column Header="Quantidade Negociada" Width="150px" DataIndex="iQuantidade" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="false">
                            </ext:RowSelectionModel>
                        </SelectionModel>
                    </ext:GridPanel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
