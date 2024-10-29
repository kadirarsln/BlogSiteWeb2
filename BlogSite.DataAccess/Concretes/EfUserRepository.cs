//using BlogSite.DataAccess.Abstracts;
//using BlogSite.DataAccess.Contexts;
//using BlogSite.Models.Entities;
//using Core.Repositories;
//using Microsoft.EntityFrameworkCore;

//namespace BlogSite.DataAccess.Concretes;

//public class EfUserRepository : EfRepositoryBase<BaseDbContext, User, long>, IUserRepository
//{
//    public EfUserRepository(BaseDbContext context) : base(context)
//    {

//    }

//    public IQueryable<User> GetAuthorWithPosts()
//    {
//        return Context.Users.Include(d => d.Posts).AsQueryable();
//    }

//    public User? GetAuthorWithPostsById(long id)
//    {
//        return Context.Users.Include(d => d.Posts).FirstOrDefault(d => d.Id == id);
//    }

//    public IQueryable<User> GetUserWithComments()
//    {
//        return Context.Users.Include(d => d.Comments).AsQueryable();
//    }

//    public User? GetUserWithCommentsById(long id)
//    {
//        return Context.Users.Include(d => d.Comments).FirstOrDefault(d => d.Id == id);
//    }
//}
