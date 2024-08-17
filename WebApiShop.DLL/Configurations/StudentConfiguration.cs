using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiShop.DLL.Entites;

namespace WebApiShop.DLL.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(20);
            builder
             .HasOne(s=>s.Group)
             .WithMany(g=>g.Students)
             .HasForeignKey(s=>s.GroupId)
             .OnDelete(DeleteBehavior.NoAction);

            builder
                   .Property(g => g.CreatedDate)
                   .IsRequired(true)
                   .HasDefaultValueSql("getdate()");
      


        }
    }
}
