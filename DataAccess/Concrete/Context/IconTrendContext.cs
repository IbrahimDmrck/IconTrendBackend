using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class IconTrendContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-4VOSQ2D;Database=IconTrend;Trusted_Connection=true");
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Congress> Congresses { get; set; }
        public DbSet<CongressImage> CongressImages { get; set; }
        public DbSet<EmailQueue> EmailQueues { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<PaperFile> PaperFiles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TransportLayover> TransportLayovers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
