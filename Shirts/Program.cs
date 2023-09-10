using Microsoft.EntityFrameworkCore;
using Shirts.Data;

var builder = WebApplication.CreateBuilder(args);
// services for DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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


