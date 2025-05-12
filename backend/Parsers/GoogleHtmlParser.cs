using InfoTrack.Parsers.Interfaces;
using System.Text.RegularExpressions;

namespace InfoTrack.Parsers
{
    public class GoogleHtmlParser : IHtmlParser
    {
        private const string regexPattern = @"<a[^>]*>.*?</a>";
        public List<int> ExtractPositions(string html, string targetUrl)
        {
            var matches = Regex.Matches(html, regexPattern, RegexOptions.IgnoreCase);

            var positions = new List<int>();

            var position = 1;
            foreach (Match match in matches)
            {
                if (match.Value.Contains(targetUrl, StringComparison.OrdinalIgnoreCase))
                {
                    positions.Add(position);
                }

                position++;
            }

            if (!positions.Any())
            {
                positions.Add(0);
            }

            return positions;
        }
    }
}
