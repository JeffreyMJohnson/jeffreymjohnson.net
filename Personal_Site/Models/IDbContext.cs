using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Site.Models
{
    public interface IDbContext
    {
        DbSet<BlogPost> BlogPosts { get; set; }
        DbSet<Project> Projects { get; set; }

        int SaveChanges();
    }
}
