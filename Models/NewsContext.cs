using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEWS_SITE.Models
{
    public class NewsContext : DbContext
    {
        
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }
        public DbSet<Catogery> catogeries { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Teammember> teammembers{ get; set; }
        public DbSet<Contactus> contactus { get; set; }
    
    
    }
}
