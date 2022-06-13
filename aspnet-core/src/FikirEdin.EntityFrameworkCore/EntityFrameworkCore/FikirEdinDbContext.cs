using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FikirEdin.Authorization.Roles;
using FikirEdin.Authorization.Users;
using FikirEdin.MultiTenancy;
using FikirEdin.Products;
using FikirEdin.Categories;
using FikirEdin.Contacts;
using FikirEdin.Blogs;

namespace FikirEdin.EntityFrameworkCore
{
    public class FikirEdinDbContext : AbpZeroDbContext<Tenant, Role, User, FikirEdinDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
      
        public DbSet<ProductComment> productComments { get; set; }
        public DbSet<ProductAddLink> productAddLinks { get; set; }
        public DbSet<BlogCategory> blogCategories { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<BlogComment> blogComments { get; set; }
        public DbSet<ProductModel> productModels { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Subscriber> subscribers { get; set; }
        public FikirEdinDbContext(DbContextOptions<FikirEdinDbContext> options)
            : base(options)
        {
        }

        
    }
}
