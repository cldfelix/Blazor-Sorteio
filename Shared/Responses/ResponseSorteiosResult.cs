namespace Shared.Responses;

public class ResponseSorteiosResult
{
    public ConcorrentesResult? Idoso { get; set; }
    public ConcorrentesResult? Deficiente { get; set; }
    public List<ConcorrentesResult>? Geral { get; set; }
}
