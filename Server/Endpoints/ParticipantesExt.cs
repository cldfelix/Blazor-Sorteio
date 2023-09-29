
using API.Contracts;
using AutoMapper;
using Shared.Responses;

namespace API.Endpoints
{
    public static class ParticipantesExt
    {
        public static void MapParticipantesEndpoints(this WebApplication app)
        {
            app.MapGet("api/participantes", async (IConcorrentesService service, IMapper mapper) =>
                {
                    var participantes = await service.GetConcorrentesAsync();
                    var result  = mapper.Map<ResponseConcorrentesResult>(participantes);
                    return Results.Ok(result);
                })
                .WithName("getParticipantesAsync")
                .Produces<ResponseConcorrentesResult>();
          
        }
    }
}