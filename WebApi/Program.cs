using Lexicographics.DependencyInjectionExtensions;
using Lexicographics.Strategies.NextGreaterPermutation;
using WebApi.CustomStrategies;
using WebApi.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<CacheOptions>(builder.Configuration.GetSection("CacheOptions"));

builder.Services.AddMemoryCache();
builder.Services.AddNextPermutationStrategy();

// Uncomment here to provide custom implementation and delete previous line

//builder.Services.AddNextPermutationStrategy(options =>
//{
//    options.DefaultImplementation =
//        new ServiceDescriptor(typeof(INextGreaterPermutation), typeof(ComplexGreaterPermutation), ServiceLifetime.Scoped);
//});

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
