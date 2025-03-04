using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShipCreator.Models;

namespace ShipCreator.Data
{
    public class ShipCreatorContext : DbContext
    {
        public ShipCreatorContext (DbContextOptions<ShipCreatorContext> options)
            : base(options)
        {
        }

        public DbSet<ShipCreator.Models.Ship> Ship { get; set; } = default!;
    }
}
