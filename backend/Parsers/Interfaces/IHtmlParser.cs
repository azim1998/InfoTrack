namespace InfoTrack.Parsers.Interfaces
{
    public interface IHtmlParser
    {
        List<int> ExtractPositions(string html, string targetUrl);
    }
}
