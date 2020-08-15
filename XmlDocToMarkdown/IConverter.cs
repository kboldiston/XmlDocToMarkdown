using System.Collections.Generic;

namespace XmlDocToMarkdown.Model
{
    public interface IConverter
    {
        List<string> ToMarkdown();
    }
}
