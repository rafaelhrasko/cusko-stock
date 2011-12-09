<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Desktop.aspx.cs" Inherits="TCC_EXT.Desktop" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Cusko Alpha</title>
    <script src="Scripts/Default.js" type="text/javascript"></script>
    <style>
        .wallet
        {
            width: 48px !important;
            height: 48px !important;
            background-image: url("../images/Stocks_alt.png") !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="includes/images/Stocks_alt.png", sizingMethod="scale") !important;
        }
        .settings
        {
            width: 48px !important;
            height: 48px !important;
            background-image: url("../images/Settings.png") !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="includes/images/Settings.png", sizingMethod="scale") !important;
        }
        .report
        {
            width: 48px !important;
            height: 48px !important;
            background-image: url("../images/Stocks.png") !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="includes/images/Stocks.png", sizingMethod="scale") !important;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
    <ext:Desktop ID="MyDesktop" AutoRender="true" runat="server" BackgroundColor="Black"
        ShortcutTextColor="White" Wallpaper="">
        <StartButton Text="Iniciar" Icon="Star" />
        <Listeners>
            <ShortcutClick Handler="startModule(id);" />
        </Listeners>
        <StartMenu Width="400" Height="400" ToolsWidth="120" Title="Start Menu">
        </StartMenu>
    </ext:Desktop>
    </form>
</body>
</html>
