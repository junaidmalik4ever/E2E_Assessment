using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E2EwebAPI.Models
{
    [Table("HotelTbl")]
    public class DBHotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class HotelDbContext : DbContext
    {
        public DbSet<DBHotel> HotelData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = @"Data Source=W-674PY03-1;Initial Catalog=Junaid;Persist Security Info=True;User ID=sa;Password=Password@12345;TrustServerCertificate=True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(strConnection);
        }
    }

    public interface IHotelComponent
    {
        List<DBHotel> GetMenu();
        DBHotel GetItem(int id);
        void AddItem(DBHotel item);
        void UpdateItem(DBHotel item);
        void DeleteItem(int id);
    }
    public class HotelComponent : IHotelComponent
    {
        public void AddItem(DBHotel item)
        {
            var context = new HotelDbContext();
            context.HotelData.Add(item);
            context.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var context = new HotelDbContext();
            var rec = context.HotelData.FirstOrDefault(item => item.Id  == id);
            if (rec != null)
            {
                context.HotelData.Remove(rec);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Item not found to delete");
            }
        }
        public List<DBHotel> GetMenu()
        {
            var context = new HotelDbContext();
            return context.HotelData.ToList();
        }
        public DBHotel GetItem(int id)
        {
            var context = new HotelDbContext();
            var rec = context.HotelData.FirstOrDefault(item => item.Id == id);
            if (rec != null)
            {
                return rec;
            }
            else
            {
                throw new Exception("Item not found");
            }
        }
        public void UpdateItem(DBHotel item)
        {
            var context = new HotelDbContext();
            var rec = context.HotelData.FirstOrDefault(item => item.Id == item.Id);
            if (rec != null)
            {
                rec.Name = item.Name;
                rec.Price = item.Price;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("item not found to update");
            }
        }
    }
}