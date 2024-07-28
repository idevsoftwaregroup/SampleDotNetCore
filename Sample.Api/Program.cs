using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sample.Application.Contract.Interfaces;
using Sample.Application.Services;
using Sample.Application.Setting;
using Sample.Infrastructure.Context;
using Sample.Infrastructure.Contract.Interfaces;
using Sample.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{


//    JWTSettings settings = builder.Configuration.GetRequiredSection(JWTSettings.SECTION_NAME).Get<JWTSettings>();

//    var secretkey = Encoding.UTF8.GetBytes(settings.Secret);
//    var encryptionkey = Encoding.UTF8.GetBytes(settings.EncryptionKey);

//    var validationParameters = new TokenValidationParameters
//    {
//        ClockSkew = TimeSpan.FromMinutes(settings.ExpiryMinutes), // default: 5 min
//        RequireSignedTokens = true,

//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(secretkey),

//        RequireExpirationTime = true,
//        ValidateLifetime = true,

//        ValidateAudience = true, //default : false
//        ValidAudience = settings.Audience,

//        ValidateIssuer = true, //default : false
//        ValidIssuer = settings.Issuer,

//        TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
//    };

//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = validationParameters;

//});

#region Infastructure

builder.Services.AddScoped<ISampleRepository, SampleRepository>();

#endregion

#region Application

builder.Services.AddScoped<ISampleItemService, SampleService>();

#endregion

builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyMethod()
               .AllowAnyHeader()
               .AllowAnyOrigin();
    });
});

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection(JWTSettings.SECTION_NAME));

builder.Services.AddDbContext<SampleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API");
    options.EnableTryItOutByDefault();
});
//}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
