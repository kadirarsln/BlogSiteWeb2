using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.DataAccess.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }

    //public IQueryable<Category> GetCategoryWithPosts()
    //{
    //    return Context.Categories.Include(d => d.Posts).AsQueryable();
    //}

    //public Category? GetCategoryWithPostsById(int id)
    //{
    //    return Context.Categories.Include(d => d.Posts).FirstOrDefault(d => d.Id == id);
    //}
}
