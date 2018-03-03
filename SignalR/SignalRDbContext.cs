using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalR
{
    public class SignalRDbContext : DbContext
    {
        public SignalRDbContext() : base("SqlServerModel")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<Task> Task { get; set; }
    }
}