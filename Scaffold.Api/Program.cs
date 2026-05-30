using Scaffold.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
