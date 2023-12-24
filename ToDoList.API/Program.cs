using Microsoft.EntityFrameworkCore;
using ToDoList.BLL.Mapping.ToDoTaskMapping;
using ToDoList.DAL.Data;
using ToDoList.DAL.Repository;
using ToDoList.DAL.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add ApplicationDbContext to services.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Add ToDoListRepository to services.
builder.Services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();

// Add mapper.
builder.Services.AddAutoMapper(typeof(ToDoTaskMapper));

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
