using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DOMSharp;

namespace DOMSharp.Test
{
    [TestClass]
    public class DOMNodeTest
    {
        [TestMethod]
        public void mustParseNodeName()
        {
            string line = "<name ></name>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual("name", builder.First.Name);
        }

        [TestMethod]
        public void mustParseAttributeName()
        {
            string line = "<node name=\"value\"></node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);
            
            Assert.AreEqual("name", builder.First.Attributes[0].Name);
        }

        [TestMethod]
        public void mustParseAttributeValue()
        {
            string line = "<node name=\"value\"></node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual("value", builder.First.Attributes[0].Value);
        }

        [TestMethod]
        public void mustParseAttributeSeparated()
        {
            string line = "<node name= \"value\" > </node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual("name", builder.First.Attributes[0].Name);
            Assert.AreEqual("value", builder.First.Attributes[0].Value);
        }

        [TestMethod]
        public void mustParseInnerMsg()
        {
            string line = "<node name= \"value\" > inner </node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual(" inner ", builder.First.InnerMsg);
        }


        [TestMethod]
        public void mustParseInnerMsgWithInnerTag()
        {
            string line = "<node name= \"value\" > inner <br> child </br></node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual(" inner ", builder.First.InnerMsg);
        }

        [TestMethod]
        public void mustParseInnerMsgOfInnerTag()
        {
            string line = "<node name= \"value\" > inner <br> child </br></node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual(" child ", builder.First.Children[0].InnerMsg);
        }

        [TestMethod]
        public void mustParseInnerMsgOfSecondTag()
        {
            string line = "<node name= \"value\" > inner <br> first </br><br> second </br></node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual(" second ", builder.First.Children[1].InnerMsg);
        }

        [TestMethod]
        public void mustParseInnerMsgOfThirdLevelTag()
        {
            string line = "<node name= \"value\" > one <br> two <br> three </br></br></node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual(" one ", builder.First.InnerMsg);
            Assert.AreEqual(" two ", builder.First.Children[0].InnerMsg);
            Assert.AreEqual(" three ", builder.First.Children[0].Children[0].InnerMsg);
        }

        [TestMethod]
        public void mustParseInnerMsgOfThirdLevelSecondTag()
        {
            string line = "<node name= \"value\" > 1 <br> 2 <br> 2.1 </br><br> 2.2 </br></br></node>";
            DOMBuilder builder = new DOMBuilder();
            builder.parseHTMLFile(line);

            Assert.AreEqual(" 1 ", builder.First.InnerMsg);
            Assert.AreEqual(" 2 ", builder.First.Children[0].InnerMsg);
            Assert.AreEqual(" 2.1 ", builder.First.Children[0].Children[0].InnerMsg);
            Assert.AreEqual(" 2.2 ", builder.First.Children[0].Children[1].InnerMsg);
        }

    }
}
