using System.Xml;

namespace XmlDocToMarkdown.Model
{
    public interface IElement
    {
        IElement Create(string name);

        string ToMarkdown();

        int Compare(IElement element);
    }
}
