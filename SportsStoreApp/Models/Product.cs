using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SportsStoreApp.Models
{
    [Table("Products")]
    public class Product : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _category = string.Empty;
        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(); }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(); }
        }

        private string _status = "В наличии";
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public DateTime AddedDate { get; set; } = DateTime.Now;

        private string _manufacturer = string.Empty;
        public string Manufacturer
        {
            get => _manufacturer;
            set { _manufacturer = value; OnPropertyChanged(); }
        }

        private string _article = string.Empty;
        public string Article
        {
            get => _article;
            set { _article = value; OnPropertyChanged(); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        private string _weight = string.Empty;
        public string Weight
        {
            get => _weight;
            set { _weight = value; OnPropertyChanged(); }
        }

        private string _size = string.Empty;
        public string Size
        {
            get => _size;
            set { _size = value; OnPropertyChanged(); }
        }

        private string _color = string.Empty;
        public string Color
        {
            get => _color;
            set { _color = value; OnPropertyChanged(); }
        }

        private string _material = string.Empty;
        public string Material
        {
            get => _material;
            set { _material = value; OnPropertyChanged(); }
        }

        [NotMapped]
        public string WindowTitle => Id == 0 ? "Добавить товар" : "Редактировать товар";

        [NotMapped]
        public bool IsEditMode => Id != 0;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}