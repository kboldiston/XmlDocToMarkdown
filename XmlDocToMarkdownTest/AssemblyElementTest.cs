using NUnit.Framework;
using System;
using System.IO;
using System.Xml;
using XmlDocToMarkdown.Model;

namespace Tests
{
    [TestFixture]
    public class AssemblyElementTest
    {
        private XmlReader reader;

        [SetUp]
        public void Setup()
        {
            string assemblyFragment = $@"<assembly>
                                            <name>TestDoc</name>
                                        </assembly>";
            StringReader stringReader = new StringReader(assemblyFragment);
            reader = XmlReader.Create(stringReader);
        }

        [Test]
        public void TestMarkdownOutput()
        {
            reader.MoveToContent();
            IElement element = new AssemblyElement(reader).Create("assembly");

            Assert.AreEqual("### TestDoc", element.ToMarkdown());
        }

        [Test]
        public void TestElementNameMismatch()
        {
            Assert.Throws<XmlException>(
                new TestDelegate(BadCreateCall)
            );
        }

        private void BadCreateCall()
        {
            reader.MoveToContent();
            new AssemblyElement(reader).Create("broken");
        }
    }
}