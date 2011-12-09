using System.Xml;
using System.IO;

namespace DOMSharp
{
    public class DOMBuilder
    {
        DOMNode first;

        public DOMNode First
        {
            get
            {
                return first;
            }
        }

        public void parseHTMLFile(string file)
        {
            //if (line.Length > 1)
            //{
            //    if (line[0] == '<')
            //    {
            //        if (line[1] != '/')
            //        {
            //            MatchCollection c = Regex.Matches(@"<[^<]+?>\be(\w*)s\b", line);
            //        }
            //    }
            //}

            using (XmlReader reader = XmlReader.Create(new StringReader(file)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                DOMNode currentNode = first;
                bool isTreeStart = true;
                int lastOpenNodeId = -1;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (isTreeStart)
                            {
                                first = new DOMNode(reader.Name);
                                currentNode = first;
                                isTreeStart = false;
                            }
                            else
                            {
                                if (lastOpenNodeId == currentNode.InternalId)
                                {
                                    currentNode = currentNode.AddChild(reader.Name);
                                }
                                else
                                {
                                    currentNode = currentNode.Parent.AddChild(reader.Name);
                                    
                                }
                            }
                            lastOpenNodeId = currentNode.InternalId;

                            while (reader.MoveToNextAttribute())
                            {
                                currentNode.Attributes.Add(new DOMAttribute(reader.Name, reader.Value));
                            }
                            reader.MoveToElement();                            
                            break;
                        case XmlNodeType.Text:
                            currentNode.InnerMsg = reader.Value;
                            break;
                        case XmlNodeType.EndElement:
                            if (currentNode.Parent != null)
                            {
                                lastOpenNodeId = currentNode.Parent.InternalId;
                            }
                            //if (reader.Name == currentNode.Name)
                            //{
                            //    if (currentNode.Parent != null)
                            //    {
                            //        lastOpenNodeId = currentNode.Parent.InternalId;
                            //    }
                            //}
                            //else while (reader.Name != currentNode.Name)
                            //{
                            //    currentNode = currentNode.Parent;
                            //    lastOpenNodeId = currentNode.InternalId;
                            //}
                            break;
                    }
                }
            } //end using
        }
    }
}