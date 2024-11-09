﻿using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSite.DataAccess;

public static class DataAccessRepositoryDependencies
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(
    opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        services.AddScoped<IPostRepository, EfPostRepository>();
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();

        return services;
    }
}