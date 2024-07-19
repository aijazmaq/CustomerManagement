using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.DBContext
{
    public  class DataBaseContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public DataBaseContext( IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("TestDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(entity =>
            {
                //modelBuilder.Entity<Customer>().HasKey(x => x.Name);
                entity.HasKey(e => new {e.Name });
                //entity.ToTable("Customer1");
                //entity.Property(e=> e.Name).HasColumnName("Nm");
                //entity.HasIndex(e => e.Name).HasName("t");

                //entity.Property(e => e.Address)
                //.IsRequired()
                //.HasColumnName("address")
                //.HasMaxLength(100)
                //.IsUnicode(true)
                //.HasColumnType("text")
                //.HasDefaultValueSql("some value");


            });
            
           // modelBuilder.Entity<Customer>().HasKey(e=> new {e.Phone,e.Name});

        }

        public DbSet<Customer> customers { get; set; }


    }
}
