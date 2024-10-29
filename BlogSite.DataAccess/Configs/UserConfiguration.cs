//using BlogSite.Models.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//namespace BlogSite.DataAccess.Configs;

//public class UserConfiguration : IEntityTypeConfiguration<User>
//{
//    public void Configure(EntityTypeBuilder<User> builder)
//    {
//        builder.ToTable("Users").HasKey(x => x.Id);
//        builder.Property(u => u.Id).HasColumnName("UsserId");
//        builder.Property(u => u.CreatedDate).HasColumnName("CrateTime");
//        builder.Property(u => u.UpdatedDate).HasColumnName("UpdateTime");
//        builder.Property(u => u.FirstName).HasColumnName("FirstName");
//        builder.Property(u => u.LastName).HasColumnName("LastName");
//        builder.Property(u => u.Username).HasColumnName("Username");
//        builder.Property(u => u.Password).HasColumnName("Password");
//        builder.Property(u => u.Email).HasColumnName("Email");

//        builder
//            .HasMany(u => u.Posts)
//            .WithOne(u => u.Author)
//            .HasForeignKey(u => u.AuthorId)
//            .OnDelete(DeleteBehavior.NoAction);

//        builder
//            .HasMany(u => u.Comments)
//            .WithOne(u => u.User)
//            .HasForeignKey(u => u.UserId)
//            .OnDelete(DeleteBehavior.NoAction);
//    }
//}

