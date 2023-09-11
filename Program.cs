using market_place.Data;
using market_place.Repository;
using market_place.Repository.Interface;
using market_place.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(optionsBuilder => optionsBuilder
    .UseNpgsql(builder.Configuration.GetConnectionString("DBConnectionString")));

builder.Services.AddTransient<IBaseRepository, BaseRepository>();

builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<SubCategoryRepository>();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<SubCategoryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();