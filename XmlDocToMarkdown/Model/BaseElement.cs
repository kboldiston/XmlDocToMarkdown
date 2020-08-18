using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlDocToMarkdown.Model
{
    public class BaseElement
    {
        protected XmlReader reader;

        public BaseElement(XmlReader reader)
        {
            this.reader = reader;
        }
        
        protected string GetElement(string elementName)
        {
            while (reader.Read() && reader.LocalName != elementName)
            {
                if (reader.IsStartElement() && !reader.IsEmptyElement && reader.LocalName == elementName)
                {
                    return reader.ReadElementContentAsString();
                }
            }

            return "";
        }

        protected void ReadToNextElement()
        {
            while(reader.Read() && !reader.EOF)
            {
                if (reader.IsStartElement()) return;
            }
        }
    }
}
