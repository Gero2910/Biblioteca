var builder = WebApplication.CreateBuilder(args);

// Obtener el puerto de la variable de entorno
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";  // Usar 5000 por defecto si no se encuentra PORT

// Configura Kestrel para usar el puerto dinámico
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(int.Parse(port)); // Escuchar en el puerto proporcionado
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
