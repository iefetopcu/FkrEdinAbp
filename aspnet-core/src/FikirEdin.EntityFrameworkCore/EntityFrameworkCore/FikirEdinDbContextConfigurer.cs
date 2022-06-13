using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FikirEdin.EntityFrameworkCore
{
    public static class FikirEdinDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FikirEdinDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public static void Configure(DbContextOptionsBuilder<FikirEdinDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection, ServerVersion.AutoDetect(connection.ConnectionString));
        }
    }
}
