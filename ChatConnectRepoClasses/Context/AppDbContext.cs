using ChatConnectRepoModels;
using Microsoft.EntityFrameworkCore;

namespace ChatConnectRepoClasses.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Controllers> Controllers { get; set; }

        public DbSet<Methods> Methods { get; set; }

        public DbSet<HttpMethodType> HttpMethodType { get; set; }
    }
}
