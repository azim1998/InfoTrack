using InfoTrack.Services;
using InfoTrack.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddHttpClient<ISearchService, SearchService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()

);

app.UseAuthorization();

app.MapControllers();

app.Run();
