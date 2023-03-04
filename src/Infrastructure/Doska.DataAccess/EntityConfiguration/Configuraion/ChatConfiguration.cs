using Doska.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.DataAccess.EntityConfiguration.Configuraion
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Initializer)
                .WithMany(p => p.Chats)
                .HasForeignKey(x => x.InitializerId);
        }
    }
}
