using Shared.Models;

namespace API.Contracts
{
    public interface IConcorrentesService
    {
        Task<ResponseConcorrentes> GetConcorrentesAsync();
        Task<IQueryable<Concorrentes?>> GetAptosParaSorteioAsync();
    }
}