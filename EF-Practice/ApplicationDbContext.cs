
using Microsoft.EntityFrameworkCore;
using NewEF.Configration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEF
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCore; Integrated Security = True");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //define  one to one relation using flount API

            modelBuilder.Entity<Blog>()
        .HasOne(b => b.BlogImage)
        .WithOne(bi => bi.Blog)
        .HasForeignKey<BlogImage>(bi => bi.BlogForeginKey);
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogImage> BlogImages { get; set; }
        
    }

    // one to one relation
    public class Blog
    {
        public int BlogId { get; set; }

        [Required , MaxLength(1000)]
        public string Url { get; set; }

        public BlogImage BlogImage { get; set; }
        
    }

    public class BlogImage
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [Required, MaxLength(250)]
        public string Caption { get; set; }

        public int BlogForeginKey { get; set; }

        public Blog Blog { get; set; }

    }
}
