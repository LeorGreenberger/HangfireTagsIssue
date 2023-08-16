using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.Tags.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHangfire(config =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UsePostgreSqlStorage("Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=postgres;");
    config.UseTagsWithPostgreSql();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.MapHangfireDashboardWithAuthorizationPolicy(string.Empty);

app.Run();
