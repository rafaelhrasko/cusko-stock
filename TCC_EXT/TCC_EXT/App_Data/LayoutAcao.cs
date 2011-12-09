using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout
{
    public class LayoutAcao
    {
        // modulo
        public int SubModuleCode { get; set; }

        // action
        public int ActionCode { get; set; }
        public string ActionName { get; set; }

        // menuitem
        public string MenuItemID { get; set; }
        public string MenuItemText { get; set; }
        public Ext.Net.Icon MenuItemIcon { get; set; }
        public string MenuItemUrl { get; set; }

        // misc
        public string EventMask { get; set; }

        public Ext.Net.TreeNode getTreeNode()
        {
            return null;
        }
    }
}