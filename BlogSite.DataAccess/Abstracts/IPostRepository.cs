using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstracts
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        //List<Post> GetAllByAuthorId(long id);
    }
}
