using DGII_PruebaTecnica.Infrastructure.Data;
using DGII_PruebaTecnica.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.TeamFoundation.TestManagement.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings"]));

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(connectionString));

builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IContribuyenteRepository, contribuyenteRepository>();
builder.Services.AddTransient<IComprobantesFiscalesRepository, ComprobantesFiscalesRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MainPolicy",
      builder =>
      {
          builder
            .SetIsOriginAllowed(x => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();

      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MainPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



