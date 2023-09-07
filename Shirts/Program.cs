var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.MapControllers();
/*Als er iets aan dependencies nodig is voor de Controllers wordt dat geleverd
 * vanuit de container door AddControllers in .NET
 * */


app.Run();


