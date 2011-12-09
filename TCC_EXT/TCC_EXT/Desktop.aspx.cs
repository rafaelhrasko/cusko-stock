using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Layout;

namespace TCC_EXT
{
    public partial class Desktop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
            }
        }

        protected void Logout_Click(object sender, DirectEventArgs e)
        {
            Session.Clear();
            this.Response.Redirect("Default.aspx");

        }

        private void initModules()
        {
            List<LayoutSubModulo> modulos = LayoutXML.loadXMLModules();

            foreach (LayoutSubModulo modulo in modulos)
            {
                initShortcut(modulo);
                initStartMenu(modulo);
            }

            X.Js.Call("setLayoutModules", modulos);
        }

        private void initShortcut(LayoutSubModulo modulo)
        {
            Ext.Net.DesktopShortcut shortcut = new Ext.Net.DesktopShortcut()
            {
                ShortcutID = modulo.ShortcutID,
                Text = modulo.ShortcutText,
                IconCls = modulo.ShortcutIconCls
            };

            this.MyDesktop.Shortcuts.Add(shortcut);
        }

        private void initStartMenu(LayoutSubModulo modulo)
        {
            Ext.Net.MenuItem menuItem = new Ext.Net.MenuItem()
            {
                ID = modulo.StartMenuItemID,
                Text = modulo.StartMenuItemText,
                Icon = modulo.StartMenuItemIcon
            };
            menuItem.Listeners.Click.Handler = "startModule('" + menuItem.ID + "');";

            this.MyDesktop.StartMenu.Items.Add(menuItem);
        }

    }
}