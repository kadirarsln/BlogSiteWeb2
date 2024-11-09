using BlogSite.Models.Entities;
using Core.Exceptions;

namespace BlogSite.Service.Rules;

public sealed class PostBusinessRules
{
    public void PostIsNullCheck(Post post)
    {
        if (post is null)
        {
            throw new NotFoundException("İlgili Post Bulunamadı");
        }
    }
}
