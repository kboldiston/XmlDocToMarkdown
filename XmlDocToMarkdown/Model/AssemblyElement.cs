using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlDocToMarkdown.Model
{
    public class AssemblyElement : BaseElement, IElement
    {
        public string name;

        public AssemblyElement(XmlReader reader) : base(reader)
        {
        }

        public IElement Create(string elementName)
        {
            if(reader.LocalName == elementName)
            {
                name = GetElement("name");
            }

            else
            {
                throw new XmlException("Unexpected element name");
            }

            return this;
        }

        public string ToMarkdown() =>
            $@"### {name}";

        public int Compare(IElement element) =>
            throw new NotImplementedException();

    }
}
