using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configs;

public class PostConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(x => x.Id);
        builder.Property(p => p.Id).HasColumnName("PostId");
        builder.Property(p => p.CreatedDate).HasColumnName("CrateTime");
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdateTime");
        builder.Property(p => p.Title).HasColumnName("Title");
        builder.Property(p => p.Content).HasColumnName("Content");
        builder.Property(p => p.AuthorId).HasColumnName("Author_Id");
        builder.Property(p => p.CategoryId).HasColumnName("Category_Id");

        builder
            .HasOne(p => p.Author)                  //Postlar var
            .WithMany(p => p.Posts)               //Categorye ait
            .HasForeignKey(p => p.AuthorId)       //ForeignKey verdik 
            .OnDelete(DeleteBehavior.NoAction);     //CasCade hatası almamak adına.

        builder.HasOne(p => p.Category)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.Comments)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(x => x.Author).AutoInclude();
        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x => x.Comments).AutoInclude();
    }
}
