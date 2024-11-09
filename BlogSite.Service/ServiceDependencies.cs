
using BlogSite.Service.Abstracts;
using BlogSite.Service.Concretes;
using BlogSite.Service.Profiles.CategoriesMappingProfile;
using BlogSite.Service.Profiles.CommentsMappingProfile;
using BlogSite.Service.Profiles.PostsMappingProfile;
using BlogSite.Service.Rules;
using Core.Tokens.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSite.Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {

        services.AddAutoMapper(typeof(PostMappingProfile));
        services.AddAutoMapper(typeof(CategoryMappingProfile));
        //services.AddAutoMapper(typeof(UserMappingProfile));
        services.AddAutoMapper(typeof(CommentMappingProfile));

        services.AddScoped<PostBusinessRules>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService1, UserService1>();
        services.AddScoped<DecoderService>();

        return services;
    }
}
