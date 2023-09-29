using API.Contracts;
using AutoMapper;
using Shared.Models;
using Shared.Responses;

namespace API.Endpoints
{
    public static class SorteiosExt
    {
        public static void MapSorteiosEndpoints(this WebApplication app)
        {
            app.MapGet("api/sortear", async (ISorteioServices service, IMapper mapper) =>
                {
                    var participantes = await service.GetSorteadosAsync();
                    var result = mapper.Map<ResponseSorteiosResult>(participantes);
                    return Results.Ok(participantes);
                })
                .WithName("getSorteio")
                .Produces<ResponseSorteiosResult>();
          
        }
    }
}