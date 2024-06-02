using Microsoft.EntityFrameworkCore;

namespace WebOrder.Models
{
    public class DbContextOrder : DbContext
    {
        public DbContextOrder(DbContextOptions option) : base (option) { }

        #region Table
        public DbSet<OrderTbl> orders { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("User Id=sa;Password=1234;Server=LAPTOP-D5OKMO3H\\SQLEXPRESS;Database=OrderSystem;Trusted_Connection=True; TrustServerCertificate=true; Encrypt=false;")
                         .EnableSensitiveDataLogging(); // Bật chế độ ghi log chi tiết
        }
    }
}
