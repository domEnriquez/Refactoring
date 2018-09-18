using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTest
    {
        private void createFile(string path, string content)
        {
            if (File.Exists(path))
                File.Delete(path);

            using (FileStream fs = File.Create(path))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }

        private string filePath = Directory.GetCurrentDirectory() + "\\UnicodeFileToHtmlTextConverter\\sampleFile.txt";
        private UnicodeFileToHtmlTextConverter htmlTextConverter;

        [Test]
        public void GivenAnEmptyUnicodeFile_WhenConvertToHtml_ThenReturnEmptyString()
        {
            createFile(filePath, string.Empty);
            htmlTextConverter = new UnicodeFileToHtmlTextConverter(filePath, new HtmlEncoderImpl());

            string htmlText = htmlTextConverter.ConvertToHtml();

            Assert.AreEqual(string.Empty, htmlText);
        }

        [Test]
        public void GivenALessThanSign_WhenConvertToHtml_ThenReturnEquivalentHtmlEntity()
        {
            createFile(filePath, "<");
            htmlTextConverter = new UnicodeFileToHtmlTextConverter(filePath, new HtmlEncoderImpl());

            string htmlText = htmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&lt;<br />", htmlText);
        }

        [Test]
        public void GivenAGreaterThanSign_WhenConvertToHtml_ThenReturnEquivalentHtmlEntity()
        {
            createFile(filePath, ">");
            htmlTextConverter = new UnicodeFileToHtmlTextConverter(filePath, new HtmlEncoderImpl());

            string htmlText = htmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&gt;<br />", htmlText);
        }

        [Test]
        public void GivenADoubleQuotationMark_WhenConvertToHtml_ThenReturnEquivalentHtmlEntity()
        {
            createFile(filePath, "\"");
            htmlTextConverter = new UnicodeFileToHtmlTextConverter(filePath, new HtmlEncoderImpl());

            string htmlText = htmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&quot;<br />", htmlText);
        }

        [Test]
        public void GivenASingleQuotationMark_WhenConvertToHtml_ThenReturnEquivalentHtmlEntity()
        {
            createFile(filePath, "\'");
            htmlTextConverter = new UnicodeFileToHtmlTextConverter(filePath, new HtmlEncoderImpl());

            string htmlText = htmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&quot;<br />", htmlText);
        }

        [Test]
        public void GivenAnAmpersand_WhenConvertToHtml_ThenReturnEquivalentHtmlEntity()
        {
            createFile(filePath, "&");
            htmlTextConverter = new UnicodeFileToHtmlTextConverter(filePath, new HtmlEncoderImpl());

            string htmlText = htmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&amp;<br />", htmlText);
        }

        [Test]
        public void GivenAUnicodeFile_WhenConvertToHtml_ThenReturnEquivalentHtmlEntities()
        {
            createFile(filePath, "<html>\"ab\"" + "\r\n" +
                                 "&\'e\'");
            htmlTextConverter = new UnicodeFileToHtmlTextConverter(filePath, new HtmlEncoderImpl());

            string htmlText = htmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&lt;html&gt;&quot;ab&quot;<br />&amp;&quot;e&quot;<br />", htmlText);

        }
    }
}
