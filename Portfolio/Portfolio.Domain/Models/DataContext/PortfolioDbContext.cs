﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models.Entities;

namespace Portfolio.Domain.Models.DataContext
{
    public class PortfolioDbContext : DbContext
    {

        public PortfolioDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
