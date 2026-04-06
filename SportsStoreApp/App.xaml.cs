using System.Windows;
using SportsStoreApp.Data;
using SportsStoreApp.Models;

namespace SportsStoreApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 🔹 Создаём базу данных и таблицы, если их нет
            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            // 🔹 Добавляем админа, если таблица пустая
            if (!db.Users.Any())
            {
                db.Users.Add(new ProductUser
                {
                    Email = "admin@gmail.com",
                    PasswordHash = "admin",
                    Role = "Admin"
                });
                db.SaveChanges();
            }
        }
    }
}