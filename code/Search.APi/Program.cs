using Search.CsvInput;
using Search.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDatatReader, CsvDataReader>();
builder.Services.AddSingleton<IFilterService, FilterService>();
builder.Services.AddCors(options =>
    {
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();


app.MapGet("/cameras", (IFilterService filterService) => filterService.NoFilter())
    .WithName("GetAllCameras")
    .WithOpenApi();
app.MapGet("/cameras/{name}", (string name , IFilterService filterService) => filterService.FilterByName(name))
    .WithName("GetCamerasByName")
    .WithOpenApi();
app.MapGet("/ping", () => "Pong")
    .WithName("Ping")
    .WithOpenApi();
app.Run();
