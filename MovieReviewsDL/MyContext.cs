using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewsEL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace MovieReviewsDL
{
    public class MyContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public MyContext()
        {

        }

        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAMAZAN-PC\\SQLEXPRESS;Database=MovieReviewsDB;Trusted_Connection=True;Trust Server Certificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                            .HasOne(r => r.Film)
                            .WithMany(f => f.Reviews)
                            .HasForeignKey(r => r.FilmId);

            base.OnModelCreating(modelBuilder);
            
        }
    }

}
