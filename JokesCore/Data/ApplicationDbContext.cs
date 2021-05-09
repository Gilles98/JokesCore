using System;
using System.Collections.Generic;
using System.Text;
using JokesCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JokesCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Joke> Jokes { get; set; }

        public DbSet<Categorie> Categorieën { get; set; }

        public DbSet<JokeCategorie> JokeCategorieën { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JokesCore");
            modelBuilder.Entity<Joke>().ToTable("Joke");

            modelBuilder.Entity<Categorie>().ToTable("Categorie");

            modelBuilder.Entity<JokeCategorie>().ToTable("JokeCategorie");
            base.OnModelCreating(modelBuilder);
        }
    }
}
