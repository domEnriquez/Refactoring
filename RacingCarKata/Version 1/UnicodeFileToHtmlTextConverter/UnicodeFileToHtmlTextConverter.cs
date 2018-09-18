using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private string fileNameWithPath;
        private HtmlEncoder htmlEncoder;

        public UnicodeFileToHtmlTextConverter(string fileNameWithPath)
        {
            this.fileNameWithPath = fileNameWithPath;
            htmlEncoder = new HtmlEncoderImpl();
        }

        public UnicodeFileToHtmlTextConverter(string fileNameWithPath, HtmlEncoder encoder)
        {
            this.fileNameWithPath = fileNameWithPath;
            htmlEncoder = encoder;
        }

        public string GetFilename()
        {
            return fileNameWithPath;
        }

        public string ConvertToHtml()
        {
            using (TextReader fileStream = File.OpenText(fileNameWithPath))
            {
                string html = string.Empty;
                string line = fileStream.ReadLine();

                while (line != null)
                {
                    html += htmlEncoder.HtmlEncode(line);
                    html += htmlEncoder.BreakLine();
                    line = fileStream.ReadLine();
                }

                return html;
            }
        }
    }
}
