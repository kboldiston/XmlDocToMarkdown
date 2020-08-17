using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlDocToMarkdown.Model
{
    public class MembersElement : BaseElement, IElement
    {
        public string name;

        IList<IElement> members;

        public MembersElement(XmlReader reader) : base(reader)
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
                members = new List<IElement>();

                reader.Read();
                while(reader.LocalName == "member")
                {
                    IElement member = new MemberElement(reader).Create("member");
                    members.Add(member);

                    reader.Read();
                }
            }

            else
            {
                throw new XmlException(@$"Unexpected element name: {elementName}");
            }

            return this;
        }

        public string ToMarkdown()
        {
            IEnumerable<string> output = members.Select(element => element.ToMarkdown());
            
            return string.Join("\n\n", output);
        }
    }
}
