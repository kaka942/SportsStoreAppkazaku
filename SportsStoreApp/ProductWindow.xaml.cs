using System.Windows;
using System.Windows.Controls;
using SportsStoreApp.Models;
using SportsStoreApp.Data;

namespace SportsStoreApp
{
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();

            var product = new Product
            {
                Status = "В наличии",
                Category = "Спортивная одежда",
                Price = 0,
                Quantity = 0
            };
            DataContext = product;

            cmbStatus.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
        }

        public ProductWindow(Product product)
        {
            InitializeComponent();
            DataContext = product;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not Product product)
            {
                MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получаем категорию из ComboBox
            string categoryValue = "";
            if (cmbCategory.SelectedItem is ComboBoxItem categoryItem)
            {
                categoryValue = categoryItem.Content.ToString();
            }

            // Устанавливаем значения
            product.Status = "В наличии";
            product.Category = string.IsNullOrWhiteSpace(categoryValue) ? "Спортивная одежда" : categoryValue;

            // Проверяем обязательные поля
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                MessageBox.Show("Введите наименование товара!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (product.Price <= 0)
            {
                MessageBox.Show("Цена должна быть больше 0!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Сохраняем в базу
            bool success = product.Id == 0
                ? DatabaseHelper.AddProduct(product)
                : DatabaseHelper.UpdateProduct(product);

            if (success)
            {
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}