<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="pnlMain.aspx.cs" Inherits="TCC_EXT.pnlMain" %>

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
    <ext:Panel runat="server" ID="pnlMainForm" ForceLayout="true" Layout="FitLayout"
        AnchorHorizontal="100%" AnchorVertical="100%" MonitorResize="true">
        <Items>
            <ext:GridPanel runat="server" ID="gdpLOL" AutoHeight="true" MonitorWindowResize="true"
                Region="Center" Title="Últimas Operações Realizadas" Collapsible="true">
                <Store>
                    <ext:Store runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Name" />
                                    <ext:RecordField Name="Price" />
                                    <ext:RecordField Name="Change" />
                                    <ext:RecordField Name="PctChange" />
                                    <ext:RecordField Name="IQuant" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server" DefaultWidth="120">
                    <Columns>
                        <ext:RowNumbererColumn />
                        <ext:Column ColumnID="Company" Header="Company" Width="160" DataIndex="Name" />
                        <ext:Column Header="Valor de Compra" DataIndex="Price">
                            <Renderer Format="UsMoney" />
                        </ext:Column>
                        <ext:Column Header="Valor" DataIndex="Change">
                            <Renderer Fn="change" />
                        </ext:Column>
                        <ext:Column Header="Percentual/Ganho" DataIndex="PctChange">
                            <Renderer Fn="pctChange" />
                        </ext:Column>
                        <ext:Column Header="Quantidade Adquirida" DataIndex="IQuant">
                        </ext:Column>
                    </Columns>
                </ColumnModel>
            </ext:GridPanel>
            <ext:GridPanel ID="gdpSaldo" Title="Saldo disponível" runat="server" AutoHeight="true"
                MonitorWindowResize="true" Region="Center" Collapsible="true">
                <Store>
                    <ext:Store runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Escrita" Mapping="strNomeSaldo" />
                                    <ext:RecordField Name="Saldo" Mapping="strValorSaldo" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column DataIndex="Escrita">
                        </ext:Column>
                        <ext:Column DataIndex="Saldo">
                        </ext:Column>
                        <ext:CommandColumn>
                            <Commands>
                                <ext:GridCommand Icon="Add" CommandName="Edit">
                                    <ToolTip Text="Adicionar Saldo" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
            </ext:GridPanel>
        </Items>
    </ext:Panel>
</asp:Content>
