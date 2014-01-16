using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Sanscs.Homework.Common.Helpers;
namespace Sanscs.Homework.QuestionImport
{
    public class QuestionResolverBase
    {
        protected virtual Dictionary<string,string> GetProperties(string input)
        {
            Regex regexProperty = new Regex(RegexPool.Property, RegexOptions.Multiline);
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            Match match = regexProperty.Match(input);
            while (match.Success)
            {
                pairs.Add(match.Groups["property"].ToString(), match.Groups["value"].ToString());
                match = match.NextMatch();
            }
            return pairs;
        }

        protected virtual Dictionary<string, string> GetChoices(string input)
        {
            Regex regexProperty = new Regex(RegexPool.Choices, RegexOptions.Multiline);
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            Match match = regexProperty.Match(input);
            while (match.Success)
            {
                pairs.Add("choice", match.Groups["choice"].ToString());
                match = match.NextMatch();
            }
            return pairs;
        }

        protected virtual Dictionary<string, string> GetContent(string input)
        {
            Regex regexProperty = new Regex(RegexPool.Content, RegexOptions.Multiline);
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            Match match = regexProperty.Match(input);
            if (match.Success)
            {
                pairs.Add("content", match.Groups["content"].ToString());
            }
            return pairs;
        }
    }
}
