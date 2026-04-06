using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SportsStoreApp.Models;
using SportsStoreApp.Data;

namespace SportsStoreApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadProductsFromDatabase();
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Поиск товаров...")
            {
                txtSearch.Text = "";
                txtSearch.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Поиск товаров...";
                txtSearch.Foreground = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            }
        }

        private void LoadProductsFromDatabase()
        {
            var products = DatabaseHelper.GetProducts();
            dgProducts.ItemsSource = products;
            txtTotalItems.Text = products.Count.ToString();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductWindow();
            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                LoadProductsFromDatabase();
                System.Windows.MessageBox.Show("Товар добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
            {
                var window = new ProductWindow(selectedProduct);
                window.Owner = this;

                if (window.ShowDialog() == true)
                {
                    LoadProductsFromDatabase();
                    System.Windows.MessageBox.Show("Товар обновлён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Выберите товар!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
            {
                var result = System.Windows.MessageBox.Show($"Удалить \"{selectedProduct.Name}\"?",
                                             "Подтверждение",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    if (DatabaseHelper.DeleteProduct(selectedProduct.Id))
                    {
                        LoadProductsFromDatabase();
                        System.Windows.MessageBox.Show("Товар удалён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Выберите товар для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var result = System.Windows.MessageBox.Show("Выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}