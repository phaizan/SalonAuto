using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Storage.Database;
using Microsoft.Extensions.Logging;
using SalonAuto.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var logger = LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger("Program");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
logger.LogInformation($"Connection string loaded: {connectionString}");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The connection string 'DefaultConnection' was not found.");
}

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString, o =>
    {
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));

// Добавление других сервисов
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddWebServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "AutoSalon", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    foreach (FileInfo file in new DirectoryInfo(AppContext.BaseDirectory).GetFiles(
                 Assembly.GetExecutingAssembly().GetName().Name! + ".xml"))
        c.IncludeXmlComments(file.FullName);

    c.EnableAnnotations(enableAnnotationsForInheritance: true,
        enableAnnotationsForPolymorphism: true
    );
});

var app = builder.Build();

// Конфигурация HTTP-запросов
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoSalon");
        options.RoutePrefix = string.Empty;
        options.EnableDeepLinking();
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
