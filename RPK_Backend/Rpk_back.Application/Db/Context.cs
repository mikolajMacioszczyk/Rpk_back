using Microsoft.EntityFrameworkCore;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Db
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        { }

        public DbSet<Sensor> SensorItems { get; set; }
    }
}