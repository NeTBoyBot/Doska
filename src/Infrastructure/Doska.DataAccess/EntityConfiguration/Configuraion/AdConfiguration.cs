﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doska.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doska.DataAccess.EntityConfiguration.Configuraion
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Description).HasMaxLength(800);

            builder.HasOne(x => x.User)
                .WithMany(p => p.Ads)
                .HasForeignKey(x=>x.UserId);
        }
    }
}
