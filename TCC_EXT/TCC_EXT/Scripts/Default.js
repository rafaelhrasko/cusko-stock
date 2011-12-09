

    var template = '<span style="color:{0};">{1}</span>';

    var layoutWindows = new Array();

    var setLayoutModules = function (object) {
        //alert(object.length);
        //        for (var layoutModule in object) {
        //            
        //        }

        layoutWindows = object;
    }

    var startModule = function (itemID) {
        for (var i = 0; i < layoutWindows.length; i++) {
            //alert(layoutWindows[i].ShortcutID);
            if (layoutWindows[i].ShortcutID == itemID || layoutWindows[i].StartMenuItemID == itemID) {
                verificaWindow(layoutWindows[i]);
            }
        }
    }

    var verificaWindow = function (object) {
        if (Ext.get(object.WindowID)) {
            Ext.getCmp(object.WindowID).show();
        } else {
            Ext.net.Mask.show({ msg: 'Carregando...' });
            Ext.net.DirectMethods.createWindow(object);
        }
    }

    var change = function (value) {
        return String.format(template, (value > 0) ? "green" : "red", value);
    };

    var pctChange = function (value) {
        return String.format(template, (value > 0) ? "green" : "red", value + "%");
    };

    var alignPanels = function () {
        pnlSample.getEl().alignTo(Ext.getBody(), "tr", [-505, 5], false)
    };

   
    var createDynamicWindow = function (app) {
        var desk = app.getDesktop();

        var w = desk.createWindow({
            title: "Dynamic Web Browser",
            width: 1000,
            height: 600,
            maximizable: true,
            minimizable: true,
            autoLoad: {
                url: "http://ajaxian.com/archives/mad-cool-date-library/",
                mode: "iframe",
                showMask: true
            }
        });

        w.center();
        w.show();
    };

