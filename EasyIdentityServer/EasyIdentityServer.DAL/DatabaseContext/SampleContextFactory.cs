
using EasyIdentityServer.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class SampleContextFactory : IDesignTimeDbContextFactory<EasyIdentityDbContext>
{
    public EasyIdentityDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EasyIdentityDbContext>();

        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();

        string connectionString = config.GetSection("Database:ConnectionString").Value;
        optionsBuilder.UseNpgsql(connectionString);
        return new EasyIdentityDbContext(optionsBuilder.Options);
    }
}