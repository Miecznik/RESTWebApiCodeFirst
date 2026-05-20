using Microsoft.EntityFrameworkCore;
using RESTWebApiCodeFirst.Data;
using RESTWebApiCodeFirst.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDbService, DBService>();
builder.Services.AddDbContext<AppDBContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/openapi/v1.json", "RESTWebApiCodeFirst"); });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

