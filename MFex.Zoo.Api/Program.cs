using MFex.Zoo.Application.Interfaces;
using MFex.Zoo.Application.UseCases;
using MFex.Zoo.Domain.IRepository;
using MFex.Zoo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IZooUseCase, ZooUseCase>();
builder.Services.AddSingleton<IZooRepository>(_ =>
{
    var rootPath = Path.Combine(builder.Environment.ContentRootPath, "sources");
    return new ZooRepository(rootPath);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
