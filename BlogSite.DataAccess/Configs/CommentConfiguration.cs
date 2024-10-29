using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Configs
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments").HasKey(x => x.Id);
            builder.Property(c => c.Id).HasColumnName("CommentId");
            builder.Property(c => c.CreatedDate).HasColumnName("CrateTime");
            builder.Property(c => c.UpdatedDate).HasColumnName("UpdateTime");
            builder.Property(c => c.Text).HasColumnName("Text").IsRequired();
            builder.Property(c => c.PostId).HasColumnName("Post_Id");
            builder.Property(c => c.UserId).HasColumnName("User_Id");

            builder
                .HasOne(c => c.User)                  //Postlar var
                .WithMany(c => c.Comments)               //Categorye ait
                .HasForeignKey(c => c.UserId)       //ForeignKey verdik                
                .OnDelete(DeleteBehavior.NoAction);     //CasCade hatası almamak adına.

            builder
                .HasOne(c => c.Post)                  //Postlar var
                .WithMany(c => c.Comments)               //Categorye ait
                .HasForeignKey(c => c.PostId)       //ForeignKey verdik                
                .OnDelete(DeleteBehavior.NoAction);     //CasCade hatası almamak adına.

            builder.Navigation(x => x.User).AutoInclude();
            builder.Navigation(x => x.Post).AutoInclude();
            
        }
    }
}
