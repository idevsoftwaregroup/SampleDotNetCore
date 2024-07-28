using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Context
{
    public class SampleContext : DbContext
    {
        public DbSet<SampleItems> SampleItems { get; set; }

        public SampleContext(DbContextOptions<SampleContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SampleItems

            modelBuilder.Entity<SampleItems>().Property(p => p.SampleTitle).IsRequired();
            
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
