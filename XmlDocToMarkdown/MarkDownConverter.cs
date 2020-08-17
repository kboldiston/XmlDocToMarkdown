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

            elements = new List<IElement>();
            while(reader.Read() && !reader.EOF)
            {
                AssemblyElement assembly = new AssemblyElement(reader);
                elements.Add(assembly);
            }
        }

        public string ToMarkdown()
        {
            IList<string> output = elements.Select(element => element.ToMarkdown()).ToList();

            return string.Join("\n\n", output);
        }
    }
}
