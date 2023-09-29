using Shared.Models;

namespace API.Contracts
{
    public interface ISorteioServices
    {
        Task<ResponseSorteioConcorrentes> GetSorteadosAsync();
    }
}