using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Concretes;
using BlogSite.Service.Profiles.CategoriesMappingProfile;
using BlogSite.Service.Profiles.CommentsMappingProfile;
using BlogSite.Service.Profiles.PostsMappingProfile;
using BlogSite.Service.Profiles.UsersMappingProfile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(typeof(PostMappingProfile));
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
//builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddAutoMapper(typeof(CommentMappingProfile));

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IUserService1, UserService1>();

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
