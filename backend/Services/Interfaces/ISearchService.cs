using InfoTrack.Models;

namespace InfoTrack.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResult> GetSearchResultAsync(SearchRequst searchRequest);
    }
}
