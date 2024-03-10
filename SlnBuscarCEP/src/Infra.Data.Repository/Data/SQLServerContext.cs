using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Data
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options)
            :base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new { Id = 1, Email = "admin@gmail.com", Password = "admin"},
                new { Id = 2, Email = "yasmin@gmail.com", Password = "123"}
                );

        }


        #region DBSets

        public DbSet<User> Users { get; set; }


        #endregion
    }
}
