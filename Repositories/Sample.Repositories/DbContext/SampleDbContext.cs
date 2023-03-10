using Sample.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace Sample.Repositories
{
    public class SampleDbContext : DbContext
    {
        public virtual DbSet<Employee> employees { get; set; }
        public SampleDbContext() { }

    }
}
