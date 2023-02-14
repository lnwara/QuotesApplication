using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quotes.Models;

namespace Quotes.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
      
        public DbSet<QuotesModel> Quotes { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }

    }
}

