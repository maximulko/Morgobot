using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using Dagon.Grammar;

namespace Morgobot.Brain
{
    public class GoogleAnalyzer : IAnalyzer
    {
        public int Order => 3;

        public string Analyse(Phrase phrase)
        {
            if (!phrase.IsFirstWordEquals("загугли"))
                return null;

            var term = HttpUtility.UrlEncode(phrase.RemoveFirstWord().ToString());
            var url = $"http://www.google.com/search?num=1&q={term}";
            string html;

            using (var webClient = new WebClient())
            {
                html = webClient.DownloadString(url);
            }

            var regex = new Regex("<div class=\"g\">(.*?)</div>");
            var matches = regex.Matches(html).Cast<Match>().ToList();

            if (!matches.Any())
                return null;

            var firstMatch = matches.First().Value;

            var regex2 = new Regex("<a href=\"(.*?)&amp;(.*?)\">(.*?)a>");
            var matches2 = regex2.Matches(firstMatch).Cast<Match>().ToList();

            if (!matches2.Any())
                return null;

            var requiredUrl = matches2.First().Groups[1].Value;
            if (requiredUrl.StartsWith("/url?q="))
            {
                requiredUrl = requiredUrl.Substring(7, requiredUrl.Length - 7);
            }

            requiredUrl = HttpUtility.UrlDecode(requiredUrl);
            requiredUrl = HttpUtility.UrlDecode(requiredUrl);

            return requiredUrl.StartsWith("/search") ? "Это секретная информация!" : requiredUrl;
        }
    }
}
