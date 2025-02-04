var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
    
});

var app = builder.Build();

app.MapOpenApi("/");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
