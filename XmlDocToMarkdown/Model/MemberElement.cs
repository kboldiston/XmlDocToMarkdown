using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlDocToMarkdown.Model
{
    public class MemberElement : BaseElement, IElement
    {
        private string name;

        public MemberElement(XmlReader reader) : base(reader)
        {
        }

        public int Compare(IElement element)
        {
            throw new NotImplementedException();
        }

        public IElement Create(string elementName)
        {
            if (reader.LocalName == elementName)
            {
                reader.ReadAttributeValue();
                name = reader.Value;
            }

            else
            {
                throw new XmlException("Unexpected element name");
            }

            return this;
        }

        public string ToMarkdown()
        {
            return $@"#### {name} <br/>";
        }
    }
}
