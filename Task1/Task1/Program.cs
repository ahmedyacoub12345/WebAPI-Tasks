using Microsoft.EntityFrameworkCore;
using Task1.Models;

var builder = WebApplication.CreateBuilder(args);

// to connect back-end with front-end
builder.Services.AddCors(options =>
options.AddPolicy("Development", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
})
);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommerceCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconn")));
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//and this code for connect with front-end
app.UseCors("Development");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
