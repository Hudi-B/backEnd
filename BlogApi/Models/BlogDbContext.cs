﻿using Microsoft.EntityFrameworkCore;

namespace BlogApi.Models
{
    public class Bl ogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<BlogUser> BlogUsers { get; set; } = null!;
        public DbSet<BlogUserContent> BlogUserContent { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=192.168.50.166; database=Blog; user=root; password=password";

                optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
            }
        }
    }
}
