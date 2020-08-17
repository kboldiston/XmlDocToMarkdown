using System.Xml;

namespace XmlDocToMarkdown.Model
{
    public interface IElement
    {
        IElement Create(string elementName);

        string ToMarkdown();

        int Compare(IElement element);
    }
}
