using System;
using System.IO;
using XmlDocToMarkdown.Model;

namespace XmlDocToMarkdown
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = args[0];

            string outputFilePath = !string.IsNullOrEmpty(inputFilePath) ?
                Path.ChangeExtension(inputFilePath, ".md") :
                string.Empty;

            using (FileStream inputFile = File.OpenRead(inputFilePath))
            {
                IConverter converter = new MarkDownConverter(inputFile);
            }

        }
    }
}
