using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warhammer_Collection.Models;

namespace Warhammer_Collection.Data
{
    public class Warhammer_CollectionContext : DbContext
    {
        public Warhammer_CollectionContext (DbContextOptions<Warhammer_CollectionContext> options)
            : base(options)
        {
        }

        public DbSet<Warhammer_Collection.Models.Mini> Mini { get; set; } = default!;
    }
}
