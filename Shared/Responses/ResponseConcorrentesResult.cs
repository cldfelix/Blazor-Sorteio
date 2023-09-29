using Shared.Models;

namespace Shared.Responses;

public class ResponseConcorrentesResult
{
    public List<ConcorrentesResult>? Idosos { get; set; }
    public List<ConcorrentesResult>? Deficientes { get; set; }
    public List<ConcorrentesResult>? Geral { get; set; }
    public int Total { get;  set; }
}
