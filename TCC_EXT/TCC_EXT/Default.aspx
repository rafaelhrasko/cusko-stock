<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="TCC_EXT._Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Cusko Alpha</title>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Window ID="Window1" runat="server" Closable="false" Resizable="false" AutoHeight="true"
        Icon="Lock" Title="Login" Draggable="false" Width="400px" Modal="true" Padding="5"
        Layout="Form">
        <Items>
            <ext:TextField ID="txtUsuario" runat="server" FieldLabel="Username" AllowBlank="false"
                BlankText="O login é obrigatório" Text="Usuário" AutoWidth="true" />
            <ext:TextField ID="txtPassword" runat="server" InputType="Password" FieldLabel="Password"
                AllowBlank="false" BlankText="O password é obrigatório" Text="Password" AutoWidth="true" />
        </Items>
        <Buttons>
            <ext:Button ID="Button1" runat="server" Text="Login" Icon="Accept">
                <DirectEvents>
                    <Click OnEvent="Button1_Click">
                        <EventMask ShowMask="true" />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
