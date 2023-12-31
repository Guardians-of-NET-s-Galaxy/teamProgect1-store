﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.Entities.Payments;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.AppDbContext
{
    public class ShopDbContext : DbContext
    {
        #region ctor

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        #endregion

        #region db sets

        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserInRole> UserInRoles { get; set; }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Payment> payments { get; set; }

        #endregion

        #region model creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion

    }
}
