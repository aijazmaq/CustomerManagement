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
        public DataBaseContext(IConfiguration configuration, DbContextOptions<DataBaseContext> options) : base(options)
        {
            _configuration = configuration;
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // in memory database used for simplicity, change to a real db for production applications
        //   // options.UseInMemoryDatabase("TestDb");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(entity =>
            {
                //entity.ToTable("Customer1");
                entity.HasKey(e => e.CustomerId);
                //entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
                entity.Property(e => e.Name).HasColumnName("Name");
                //entity.Property(e => e.Phone).HasColumnName("Phone");
                //entity.Property(e => e.Email).HasColumnName("Email");
                //entity.Property(e => e.Address).HasColumnName("Address");
                ////entity.HasIndex(e => e.Name).HasName("t");

                //entity.Property(e => e.Address)
                //.IsRequired()
                //.HasColumnName("address")
                //.HasMaxLength(100)
                //.IsUnicode(true)
                //.HasColumnType("text")
                //.HasDefaultValueSql("some value");

            });

        }

        public DbSet<Customer> customer { get; set; }


    }
}
