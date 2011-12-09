<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="pnlCarteira.aspx.cs" Inherits="TCC_EXT.pnlCarteira" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:GridPanel runat="server" ID="gdpAcoesCadastradas" AutoHeight="true" MonitorWindowResize="true"
        Region="Center" Title="Ações em Observação" Collapsible="true">
        <Store>
            <ext:Store ID="Store1" runat="server">
                <Reader>
                    <ext:ArrayReader>
                        <Fields>
                            <ext:RecordField Name="company" />
                            <ext:RecordField Name="price" Type="Float" />
                            <ext:RecordField Name="change" Type="Float" />
                            <ext:RecordField Name="pctChange" Type="Float" />
                            <ext:RecordField Name="lastChange" Type="Date" DateFormat="d/M hh:mmtt" />
                            <ext:RecordField Name="IQuant" />
                        </Fields>
                    </ext:ArrayReader>
                </Reader>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:Column Header="Nome" Width="160" DataIndex="company" />
                <ext:Column Header="Código" Width="160" DataIndex="company" />
                <ext:Column Header="Quantidade" Width="160" DataIndex="company" />
                <ext:Column Header="Preço de Compra" Width="160" DataIndex="company" />
                <ext:Column Header="Variação" Width="75" DataIndex="change">
                    <Renderer Fn="change" />
                </ext:Column>
                <ext:Column Header="Última Abertura" Width="75" DataIndex="price">
                    <Renderer Format="UsMoney" />
                </ext:Column>
                <ext:Column Header="Último Fechamento" Width="75" DataIndex="price">
                    <Renderer Format="UsMoney" />
                </ext:Column>
                <ext:Column Header="Mínima" Width="75" DataIndex="price">
                    <Renderer Format="UsMoney" />
                </ext:Column>
                <ext:Column Header="Máxima" Width="75" DataIndex="price">
                    <Renderer Format="UsMoney" />
                </ext:Column>
                <ext:Column Header="Média" Width="75" DataIndex="price">
                    <Renderer Format="UsMoney" />
                </ext:Column>
                <ext:Column Header="Ações no Mercado" Width="75" DataIndex="pctChange">
                </ext:Column>
                <ext:Column Header="Volume" Width="75" DataIndex="pctChange">
                </ext:Column>
                <ext:DateColumn Header="Ultimo Update" Width="85" DataIndex="lastChange" />
                <ext:CommandColumn Width="60">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="Delete">
                            <ToolTip Text="Excluir" />
                        </ext:GridCommand>
                        <ext:CommandSeparator />
                        <ext:GridCommand Icon="Add" CommandName="Edit">
                            <ToolTip Text="Adicionar a carteira" />
                        </ext:GridCommand>
                    </Commands>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="false" />
        </SelectionModel>
        <Listeners>
            <Command Handler="Ext.Msg.alert(command, record.data.company);" />
        </Listeners>
        <BottomBar>
            <ext:StatusBar runat="server">
                <Items>
                    <ext:Button runat="server" Icon="NoteEdit" ToolTip="Comparar Ações">
                    </ext:Button>
                    <ext:Button runat="server" Icon="Note" ToolTip="Ver Histórico">
                    </ext:Button>
                </Items>
            </ext:StatusBar>
        </BottomBar>
    </ext:GridPanel>
</asp:Content>
