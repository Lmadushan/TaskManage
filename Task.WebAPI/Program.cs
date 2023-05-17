using FluentValidation.AspNetCore;
using TaskManage.Common.Extensions;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors(configuration);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterDependencies();

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
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

app.UseCors("CorsProlicy");

// global error handler
app.UseCustomExceptionHandler();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    //.RequireAuthorization();
});
