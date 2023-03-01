using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doska.DataAccess.DataBase;

namespace Doska.Migrations
{
    public class MigrationsDbContext : DoskaContext
    {
        public MigrationsDbContext(DbContextOptions<MigrationsDbContext> options) : base(options)
        {

        }
    }
}
