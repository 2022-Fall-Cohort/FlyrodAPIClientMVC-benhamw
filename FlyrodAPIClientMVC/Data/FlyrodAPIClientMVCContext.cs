using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlyrodAPIClientMVC.Models;

namespace FlyrodAPIClientMVC.Data
{
    public class FlyrodAPIClientMVCContext : DbContext
    {
        public FlyrodAPIClientMVCContext (DbContextOptions<FlyrodAPIClientMVCContext> options)
            : base(options)
        {
        }

        public DbSet<FlyrodAPIClientMVC.Models.Maker> Maker { get; set; } = default!;

        public DbSet<FlyrodAPIClientMVC.Models.Flyrod> Flyrod { get; set; }
    }
}
