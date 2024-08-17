using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiShop.DLL.Entites;

namespace WebApiShop.DLL.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .Property(g => g.Name)
                .IsRequired(true)
                .HasMaxLength(20);

            builder
                .Property(g=>g.Limit)
                .IsRequired(true);

            builder
                .Property(g => g.CreatedDate)
                .IsRequired(true)
                .HasDefaultValueSql("getdate()");

        
        }
    }
}
