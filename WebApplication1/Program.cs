var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

// Sacamos Swagger del IF para que Render lo pueda mostrar
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Votos v1");
    c.RoutePrefix = string.Empty; // Para que cargue al abrir el link principal
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection(); // Mejor dejarlo comentado en Render
app.UseAuthorization();
app.MapControllers();

app.Run();