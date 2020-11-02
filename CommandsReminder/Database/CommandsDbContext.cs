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
        public DbSet<Command> Commands { get; set; }
        public DbSet<Parameter> CommandParameters { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}
