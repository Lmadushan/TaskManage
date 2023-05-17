using FluentValidation.AspNetCore;
using TaskManage.Common.Extensions;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);

//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.Console()
//    .WriteTo.Seq("http://localhost:5341"));

//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.ApplicationInsights(provider.GetRequiredService<TelemetryConfiguration>(), TelemetryConverter.Traces));

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(o =>
//{
//    o.Authority = configuration["IdentityServer:ServerUrl"];
//    o.Audience = configuration["IdentityServer:Audience"];
//    o.RequireHttpsMetadata = false;
//    o.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.Zero
//    };
//});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("CompanyAdminOnly", policy => policy.RequireClaim("isAdmin"));
//    options.AddPolicy("SysAdminOnly", policy => policy.RequireClaim("isSysAdmin"));
//});

builder.Services.ConfigureCors(configuration);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterDependencies();

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
//builder.Services.AddValidatorsFromAssemblyContaining<ProjectForCreationValidator>();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//                .AddRoles<IdentityRole>()
//                .AddEntityFrameworkStores<ApplicationDbContext>()
//                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
        //.RequireAuthorization();
});
