using InfoTrack.Models;
using InfoTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchRequst searchRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var searchResults = await _searchService.GetSearchResultAsync(searchRequest);

            if (searchResults == null)
                return StatusCode(500, "An error occurred while performing the search.");

            return Ok(searchResults);
        }
    }
}
