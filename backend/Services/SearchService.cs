using InfoTrack.Models;
using InfoTrack.Services.Interfaces;
using System.Text.RegularExpressions;

namespace InfoTrack.Services
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;
        private string regexPattern = @"<a[^>]*>.*?</a>";
        public SearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchResult?> GetSearchResultAsync(SearchRequst searchRequest)
        {
            try
            {
                var escapedKeyword = Uri.EscapeDataString(searchRequest.Keyword);
                var url = $"https://www.google.co.uk/search?num=100&q={escapedKeyword}";

                var resultHtml = await _httpClient.GetStringAsync(url);
                var target = searchRequest.TargetUrl;

                var matches = Regex.Matches(resultHtml, regexPattern, RegexOptions.IgnoreCase);

                var result = new SearchResult();

                var position = 1;
                foreach (Match match in matches)
                {
                    if (match.Value.Contains(target, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Positions.Add(position);
                    }

                    position++;
                }

                if (!result.Positions.Any())
                {
                    result.Positions.Add(0);
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
