using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectIntern_.NET.Models;

namespace ProjectIntern_.NET.Data
{
    public class ProjectIntern_NETContext : DbContext
    {
        public ProjectIntern_NETContext (DbContextOptions<ProjectIntern_NETContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<ProjectIntern_.NET.Models.ES_YDENPYOD>().HasKey(o => new { o.denpyoNO, o.gyoNO });
        }

        public DbSet<ProjectIntern_.NET.Models.ES_YDENPYO> ES_YDENPYO { get; set; } = default!;
        public DbSet<ProjectIntern_.NET.Models.BUMON> BUMON { get; set; } = default!;
        public DbSet<ProjectIntern_.NET.Models.ES_YDENPYOD> ES_YDENPYOD { get; set; } = default!;
    }
}
