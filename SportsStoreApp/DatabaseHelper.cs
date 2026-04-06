using System.Collections.ObjectModel;
using System.Linq;
using SportsStoreApp.Models;

namespace SportsStoreApp.Data
{
    public static class DatabaseHelper
    {
        public static ObservableCollection<Product> GetProducts()
        {
            using var db = new AppDbContext();
            return new ObservableCollection<Product>(db.Products.ToList());
        }

        public static bool AddProduct(Product product)
        {
            try
            {
                using var db = new AppDbContext();
                product.AddedDate = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при добавлении: {ex.Message}");
                return false;
            }
        }

        public static bool UpdateProduct(Product product)
        {
            try
            {
                using var db = new AppDbContext();
                var existing = db.Products.Find(product.Id);
                if (existing != null)
                {
                    db.Entry(existing).CurrentValues.SetValues(product);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при обновлении: {ex.Message}");
                return false;
            }
        }

        public static bool DeleteProduct(int id)
        {
            try
            {
                using var db = new AppDbContext();
                var product = db.Products.Find(id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                return false;
            }
        }

        public static ProductUser? ValidateUser(string email, string password)
        {
            using var db = new AppDbContext();
            return db.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }
    }
}