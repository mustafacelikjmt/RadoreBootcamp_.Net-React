using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  options.Authority = "https://localhost:44365/";
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateAudience = false
                  };
              });

builder.Services.AddOcelot(builder.Configuration).AddCacheManager(x => x.WithDictionaryHandle());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

await app.UseOcelot();

app.Run();