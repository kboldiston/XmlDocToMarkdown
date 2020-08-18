using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using NUnit.Framework;
using System.IO;
using System.Xml;
using XmlDocToMarkdown.Model;

namespace XmlDocToMarkdownTest
{
    [TestFixture]
    public class MembersElementTest
    {
        private XmlReader reader;

        [SetUp]
        public void Setup()
        {
            string assemblyFragment = $@"
<doc>
    <assembly>
        <name>TestDoc</name>
    </assembly>
    <members>
        <member name=""T:TestDoc.TestClass"">
            <summary>
            Class level summary documentation goes here.
            </summary>
            <remarks>
            Longer comments can be associated with a type or member through
            the remarks tag.
            </remarks>
        </member>
        <member name=""F:TestDoc.TestClass._name"">
            <summary>
            Store for the Name property.
            </summary>
        </member>
    </members>
</doc>";
            StringReader stringReader = new StringReader(assemblyFragment);
            reader = XmlReader.Create(stringReader);
        }

        [Test]
        public void TestMarkdownOutput()
        {
            reader.MoveToContent();
            reader.Read();
            reader.ReadToNextSibling("members");
            IElement element = new MembersElement(reader).Create("members");

            string expected = $@"#### T:TestDoc.TestClass \n\n\n\n#### F:TestDoc.TestClass._name \n\n";
            Assert.AreEqual(expected, element.ToMarkdown());
        }
    }
}
