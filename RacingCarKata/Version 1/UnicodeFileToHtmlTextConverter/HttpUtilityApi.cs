namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HttpUtilityApi
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("&", "&amp;")
                       .Replace("<", "&lt;")
                       .Replace(">", "&gt;")
                       .Replace("\"", "&quot;")
                       .Replace("\'", "&quot;");

            return line;
        }

        public static string BreakLine()
        {
            return "<br />";
        }
    }
}
