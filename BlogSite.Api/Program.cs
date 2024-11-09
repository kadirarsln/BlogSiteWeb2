using BlogSite.Api.Middlewares;
using BlogSite.DataAccess;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using BlogSite.Service;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Concretes;
using BlogSite.Service.Profiles.CategoriesMappingProfile;
using BlogSite.Service.Profiles.CommentsMappingProfile;
using BlogSite.Service.Profiles.PostsMappingProfile;
using BlogSite.Service.Rules;
using Core.Tokens.Config;
using Core.Tokens.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDataAccessDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();

builder.Services.Configure<TokenOption>(builder.Configuration.GetSection("TokenOption"));  //ctrodan isterken newle

builder.Services.AddHttpContextAccessor();

//builder.Services.AddScoped<IUserRepository, EfUserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>

{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<BaseDbContext>();

var tokenOption = builder.Configuration.GetSection("TokenOption").Get<TokenOption>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>              //Tokenin geçerliliðini kontrol ediyruz.
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience[0],
        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(tokenOption.SecurityKey)
    };
});

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
app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
