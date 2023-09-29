using API.Contracts;
using API.Endpoints;
using API.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped< IConcorrentesService, ConcorrentesService>();
builder.Services.AddScoped< ISorteioServices, SorteioService>();

builder.Services.AddRazorPages();

// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.MapParticipantesEndpoints();
app.MapSorteiosEndpoints();

app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();
