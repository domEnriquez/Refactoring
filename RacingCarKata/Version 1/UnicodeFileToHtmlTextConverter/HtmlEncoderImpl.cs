namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HtmlEncoderImpl : HtmlEncoder
    {
        public string HtmlEncode(string line)
        {
            return HttpUtilityApi.HtmlEncode(line);
        }

        public string BreakLine()
        {
            return HttpUtilityApi.BreakLine();
        }

    }
}
