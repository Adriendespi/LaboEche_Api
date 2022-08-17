
using LaboEchec.Api.Infrastructure;
using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.Services;
using LaboEchec.Dal.Interfaces;
using LaboEchec.Dal.Repositories;
using LaboEchec.DL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer { token}",
    
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

c.AddSecurityDefinition("Bearer", securitySchema);

var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

c.AddSecurityRequirement(securityRequirement);

});
builder.Services.AddDbContext<LaboEchecContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IMemberService,MemberService>();
builder.Services.AddScoped<ITournamentService,TournamentService>();

builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddSingleton<TokenManager>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenInfo").GetSection("secret").Value)),
        ValidateIssuer = false,
        ValidIssuer = builder.Configuration.GetSection("TokenInfo").GetSection("issuer").Value,
        ValidateAudience = false,
        ValidAudience = builder.Configuration.GetSection("TokenInfo").GetSection("audience").Value
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Auth", policy => policy.RequireAuthenticatedUser());
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
