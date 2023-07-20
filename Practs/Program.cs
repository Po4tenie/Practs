using Microsoft.EntityFrameworkCore;
using Practs;
using Practs.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DataBaseContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));
builder.Services.AddSwaggerGen(); // ���������� Swagger


var app = builder.Build();
//������������� Swagger ����������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
