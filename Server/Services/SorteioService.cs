using API.Contracts;
using API.Services.Extentions;
using Shared.Models;

namespace API.Services
{
    public class SorteioService : ISorteioServices
    {
        private readonly IConcorrentesService _concorrentesService;

        public SorteioService(IConcorrentesService concorrentesService)
        {
            _concorrentesService = concorrentesService;
        }

        public async Task<ResponseSorteioConcorrentes> GetSorteadosAsync()
        {
            var random = new Random();
            var concorrentes = await _concorrentesService.GetAptosParaSorteioAsync();

            var result = new ResponseSorteioConcorrentes
            {
                Idoso = concorrentes!.FilterByRegraIdosos().OrderBy(x => random.Next()).FirstOrDefault(),
                Deficiente = concorrentes!.FilterByDeficienciaFisica().OrderBy(x => random.Next()).FirstOrDefault()
            };

            for (var i = 0; i < 3; i++)
                result.Geral.Add(concorrentes.OrderBy(x => random.Next()).FirstOrDefault());

            return await Task.FromResult(result);
        }
    }
}