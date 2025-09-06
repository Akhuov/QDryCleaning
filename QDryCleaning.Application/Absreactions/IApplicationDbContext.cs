﻿using Microsoft.EntityFrameworkCore;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.Absreactions
{
    public interface IApplicationDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> OrderInvoices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Charge> Charges { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
