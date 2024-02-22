using CompportDataAccess.Models;
using dotnet.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CompportDataAccess.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ComputerModel> ComputerModels { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
