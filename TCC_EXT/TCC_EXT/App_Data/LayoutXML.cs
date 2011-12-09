using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;

namespace Layout
{
    public class LayoutXML
    {
        // ************************
        //         ACTIONS
        // ************************

        public static void saveXMLActions(List<LayoutAcao> actions)
        {
            using (FileStream filestream = new FileStream(HttpContext.Current.Server.MapPath("~/includes/xml/Actions.xml"), FileMode.OpenOrCreate))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(actions.GetType());
                serializer.Serialize(filestream, actions);
                filestream.Close();
            }
        }

        public static void addXMLAction(LayoutAcao action)
        {
            List<LayoutAcao> actions = loadXMLActions();
            actions.Add(action);
            saveXMLActions(actions);
        }

        public static List<LayoutAcao> loadXMLActions()
        {
            using (FileStream filestream = new FileStream(HttpContext.Current.Server.MapPath("~/includes/xml/Actions.xml"), FileMode.Open))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<LayoutAcao>));
                return (List<LayoutAcao>)serializer.Deserialize(filestream);
            }
        }

        // ************************
        //       SUB-MODULES
        // ************************

        public static void saveXMLSubModule(List<LayoutSubModulo> modules)
        {
            using (FileStream filestream = new FileStream(HttpContext.Current.Server.MapPath("~/includes/xml/SubModules.xml"), FileMode.OpenOrCreate))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(modules.GetType());
                serializer.Serialize(filestream, modules);
                filestream.Close();
            }
        }

        public static void addXMLSubModule(LayoutSubModulo module)
        {
            List<LayoutSubModulo> modulos = loadXMLModules();
            modulos.Add(module);
            saveXMLSubModule(modulos);
        }

        public static List<LayoutSubModulo> loadXMLModules()
        {
            using (FileStream filestream = new FileStream(HttpContext.Current.Server.MapPath("~/includes/xml/SubModules.xml"), FileMode.Open))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<LayoutSubModulo>));
                return (List<LayoutSubModulo>)serializer.Deserialize(filestream);
            }
        }

    }
}