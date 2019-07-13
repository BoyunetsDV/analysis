using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
                        result = GetMostFrequentSymbol();
                        break;
                    case "longesWord":
                        result = GetLongestWord();
                        break;
                    case "frequentWord":
                        result = GetMostFrequentWord();
                        break;
                    case "countSymbols":
                        result = GetCountOfSymbols();
                        break;
                    case "countWords":
                        result = GetCountOfWords();
                        break;
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

        private string GetLongestWord()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            var stringBuilder = new StringBuilder("");
            (string key, int value) pair = ("", 0);

            for (int i = 0; i < Text.Length; i++)
            {
                while (i < Text.Length && CheckIfSymbolIsNotEqualToUnnecessary(Text[i]))
                {
                    stringBuilder.Append(Text[i]);
                    i++;
                }

                if (stringBuilder.Length != 0)
                {
                    var tempString = stringBuilder.ToString().ToLower();
                    stringBuilder.Clear();
                    if (!pairs.Keys.Contains(tempString))
                    {
                        pairs.Add(tempString, tempString.Length);
                        if (pair.value < tempString.Length)
                        {
                            pair.key = tempString;
                            pair.value = tempString.Length;
                        }
                    }
                }
            }
            return $" \"{pair.key}\", length: {pair.value}";
        }

        private string GetMostFrequentWord()
        {
            int temp;
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            var stringBuilder = new StringBuilder("");
            (string key, int value) pair = ("", 0);
            for (int i = 0; i < Text.Length; i++)
            {
                while (i < Text.Length && CheckIfSymbolIsNotEqualToUnnecessary(Text[i]))
                {
                    stringBuilder.Append(Text[i]);
                    i++;
                }

                if (stringBuilder.Length != 0)
                {
                    var tempString = stringBuilder.ToString().ToLower();
                    stringBuilder.Clear();
                    if (!pairs.Keys.Contains(tempString))
                    {
                        pairs.Add(tempString, 1);
                        if (pair.value < 1)
                        {
                            pair.key = tempString;
                            pair.value = 1;
                        }
                    }
                    else
                    {
                        temp = ++pairs[tempString];
                        if (pair.value < temp)
                        {
                            if (pair.key != tempString)
                                pair.key = tempString;
                            pair.value = temp;
                        }
                    }
                }
            }
            return $" \"{pair.key}\", frequency: {pair.value}";
        }

        private string GetMostFrequentSymbol()
        {
            int temp;
            Dictionary<char, int> pairs = new Dictionary<char, int>();
            (char key, int value) pair = ('\0', 0);

            foreach (var symbol in Text)
            {
                if (CheckIfSymbolIsEqualToUnnecessary(symbol))
                    continue;

                if (!pairs.Keys.Contains(symbol))
                {
                    pairs.Add(symbol, 1);
                    if (pair.value < 1)
                    {
                        pair.key = symbol;
                        pair.value = 1;
                    }
                }
                else
                {
                    temp = ++pairs[symbol];
                    if (pair.value < temp)
                    {
                        if (pair.key != symbol)
                            pair.key = symbol;
                        pair.value = temp;
                    }
                }
            }
            return $" \"{pair.key}\", frequency: {pair.value}";
        }

        private string GetCountOfSymbols()
        {
            int count = 0;
            foreach (var symbol in Text)
            {
                if (CheckIfSymbolIsEqualToUnnecessary(symbol))
                    continue;
                count++;
            }
            return count.ToString();
        }

        private string GetCountOfWords()
        {
            int wordsCount = 0;
            bool wordStart = false;
            bool wordEnd = false;
            foreach (var symbol in Text)
            {
                if (!wordStart)
                {
                    if (CheckIfSymbolIsNotEqualToUnnecessary(symbol))
                    {
                        wordStart = true;
                        wordEnd = false;
                    }
                }
                else if (!wordEnd)
                {
                    if (CheckIfSymbolIsEqualToUnnecessary(symbol))
                        wordEnd = true;
                }

                if (wordStart && wordEnd)
                {
                    wordStart = false;
                    wordEnd = false;
                    wordsCount++;
                }
            }
            if (wordStart && !wordEnd)
                wordsCount++;
            return wordsCount.ToString();
        }

        private static bool CheckIfSymbolIsEqualToUnnecessary(char symbol)
        {
            return symbol == ' ' || symbol == '\r' || symbol == '\n' || symbol == '\t' || symbol == ',' || symbol == '.' || symbol == ';';
        }
        private bool CheckIfSymbolIsNotEqualToUnnecessary(char symbol)
        {
            return symbol != ' ' && symbol != '\r' && symbol != '\n' && symbol != '\t' && symbol != ',' && symbol != '.' && symbol!=';';
        }
    }
}
