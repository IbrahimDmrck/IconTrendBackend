﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            //MySql veritabanı bağlantı adresi
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=;database=IconTrendsDb")
                .UseLoggerFactory(LoggerFactory.Create(b => b
                 .AddFilter(level => level >= LogLevel.Information))).EnableSensitiveDataLogging().EnableDetailedErrors();


        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Congress> Congresses { get; set; }
        public virtual DbSet<CongressImage> CongressImages { get; set; }
        public virtual DbSet<EmailQueue> EmailQueues { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TransportLayover> TransportLayovers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual DbSet<TransportLayoverImage> TransportLayoverImages { get; set; }
        public virtual DbSet<CongressPresident> CongressPresidents { get; set; }
        public virtual DbSet<RegulatoryBoard> RegulatoryBoards { get; set; }
        public virtual DbSet<ScienceBoard> ScienceBoards { get; set; }

    }
}
