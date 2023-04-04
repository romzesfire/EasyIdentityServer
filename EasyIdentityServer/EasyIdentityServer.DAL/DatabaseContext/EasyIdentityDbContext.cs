using EasyIdentityServer.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyIdentityServer.DAL.DatabaseContext;

public class EasyIdentityDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public EasyIdentityDbContext(DbContextOptions<EasyIdentityDbContext> options) : base(options){ }
    
    
}