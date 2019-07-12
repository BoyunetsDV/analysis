using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace analysis.Models
{
    public class TextAnalysis
    {
        public string Action { get; set; } = "";
        public string Text { get; set; } = "";

        public string Calculate()
        {
            try
            {
                string result = "";
                switch (Action)
                {
                    case "frequentSymbol":
                    case "long":
                    case "frequentWord":
                    case "countSymbols":
                        result = Text.LongCount().ToString();
                        break;
                    case "countWords":
                    default:
                        result = "No action";
                        break;
                }
                return result;
            }
            catch
            {
                return "Error while calculating";
            }
        }
    }
}
