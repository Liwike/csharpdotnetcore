using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace l2l.Data.Model
{
    public class L2LDbContextFactory : IDesignTimeDbContextFactory<L2LDbContext>
    {
        public L2LDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<L2LDbContext>();
            //bedrótozva.... settingsből kéne velli...
            var environment = Environment.GetEnvironmentVariable(GlobalStrings.ASPCoreEnv);
            var oboulder = new DbContextOptionsBuilder<L2LDbContext>();
            var baseparh = Directory.GetCurrentDirectory();

            var cbuilder = new ConfigurationBuilder()
            .SetBasePath(baseparh)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}json", true)  //már ha van!
            .AddEnvironmentVariables();
            var config = cbuilder.Build();
            var connstr = config.GetConnectionString(GlobalStrings.ConnStr);
            
            builder.UseSqlite(connstr);  //másik adatbázis!!!! Nme fut le a teszt
            //builder.UseSqlite("Data Source=l2l.db");  //másik adatbázis!!!! Nme fut le a teszt
            return new L2LDbContext(builder.Options);
        }
    }
}