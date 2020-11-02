using CommandsReminder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsReminder.Database
{
    public class CommandsDbContext : DbContext
    {
        public CommandsDbContext(DbContextOptions<CommandsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommandPlatform>()
                .HasKey(cp => new { cp.CommandId, cp.PlatformId });

            modelBuilder.Entity<CommandPlatform>()
                .HasOne(cp => cp.Command)
                .WithMany(c => c.CommandPlatforms)
                .HasForeignKey(cp => cp.CommandId);

            modelBuilder.Entity<CommandPlatform>()
                .HasOne(cp => cp.Platform)
                .WithMany(c => c.CommandPlatforms)
                .HasForeignKey(cp => cp.PlatformId);
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Parameter> CommandParameters { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<CommandPlatform> CommandPlatforms { get; set; }
    }
}
