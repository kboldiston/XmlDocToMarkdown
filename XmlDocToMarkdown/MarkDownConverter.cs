using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace XmlDocToMarkdown.Model
{
    public class MarkDownConverter : IConverter
    {
        private readonly XmlReader reader;

        IList<IElement> elements;

        public MarkDownConverter(Stream stream)
        {
            reader = XmlReader.Create(stream);

            reader.MoveToContent();
            while(reader.Read() && !reader.EOF)
            {
                AssemblyElement assembly = new AssemblyElement(reader);
                elements.Add(assembly);
            }
        }

        public List<string> ToMarkdown()
        {
            return elements.Select(element => element.ToMarkdown())
                .ToList();
        }
    }
}
