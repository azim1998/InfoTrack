using InfoTrack.Models;
using InfoTrack.Parsers.Interfaces;
using InfoTrack.Services.Interfaces;

namespace InfoTrack.Services
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;
        private readonly IHtmlParser _htmlParser;
        public SearchService(HttpClient httpClient, IHtmlParser htmlParser)
        {
            _httpClient = httpClient;
            _htmlParser = htmlParser;
        }

        public async Task<SearchResult?> GetSearchResultAsync(SearchRequst searchRequest)
        {
            try
            {
                var escapedKeyword = Uri.EscapeDataString(searchRequest.Keyword);
                var searchUrl = $"https://www.google.co.uk/search?num=100&q={escapedKeyword}";

                var resultHtml = await _httpClient.GetStringAsync(searchUrl);
                var targetUrl = searchRequest.TargetUrl;

                var positions = _htmlParser.ExtractPositions(resultHtml, targetUrl);

                return new SearchResult { Positions = positions };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
