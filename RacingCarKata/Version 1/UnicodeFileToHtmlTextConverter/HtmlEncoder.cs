using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public interface HtmlEncoder
    {
        string HtmlEncode(string line);
        string BreakLine();
    }
}
