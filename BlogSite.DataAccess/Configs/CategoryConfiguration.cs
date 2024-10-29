using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configs;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CategoryId");
        builder.Property(x => x.CreatedDate).HasColumnName("CrateTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdateTime");
        builder.Property(x => x.Name).HasColumnName("CategoryName");

        builder
            .HasMany(x => x.Posts)                  //Postlar var
            .WithOne(x => x.Category)               //Categorye ait
            .HasForeignKey(x => x.CategoryId)       //ForeignKey verdik 
            .OnDelete(DeleteBehavior.NoAction);     //CasCade hatası almamak adına.
    }
}
