using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout
{
    public class LayoutSubModulo
    {
        // modulo
        public int SubModuleCode { get; set; }
        public string SubModuleName { get; set; }

        // shortcut 
        public string ShortcutID { get; set; }
        public string ShortcutText { get; set; }
        public string ShortcutIconCls { get; set; }

        // start menu
        public string StartMenuItemID { get; set; }
        public string StartMenuItemText { get; set; }
        public Ext.Net.Icon StartMenuItemIcon { get; set; }

        // window
        public string WindowID { get; set; }
        public string WindowUrl { get; set; }
        public string WindowIconCls { get; set; }

        // misc
        public string EventMask { get; set; }
    }

}