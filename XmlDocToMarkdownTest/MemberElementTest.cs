using NUnit.Framework;
using System.IO;
using System.Xml;
using XmlDocToMarkdown.Model;

namespace XmlDocToMarkdownTest
{
    [TestFixture]
    public class MemberElementTest
    {
        private XmlReader reader;

        [SetUp]
        public void Setup()
        {
            string assemblyFragment = $@"
        <member name=""T:TestDoc.TestClass"">
            <summary>
            Class level summary documentation goes here.
            </summary>
            <remarks>
            Longer comments can be associated with a type or member through
            the remarks tag.
            </remarks>
        </member>";
            StringReader stringReader = new StringReader(assemblyFragment);
            reader = XmlReader.Create(stringReader);
        }

        [Test]
        public void TestMarkdownOutput()
        {
            reader.MoveToContent();
            IElement element = new MemberElement(reader).Create("member");

            Assert.AreEqual($@"#### T:TestDoc.TestClass \n\n", element.ToMarkdown());
        }
    }
}
