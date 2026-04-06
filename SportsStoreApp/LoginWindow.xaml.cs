using SportsStoreApp.Data;
using SportsStoreApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace SportsStoreApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ShowLoading(true);
            HideError();

            string email = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowError("Введите email");
                ShowLoading(false);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Введите пароль");
                ShowLoading(false);
                return;
            }

            ProductUser? user = DatabaseHelper.ValidateUser(email, password);

            if (user != null)
            {
                MessageBox.Show("Добро пожаловать!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                ShowError("Неверный email или пароль");
                ShowLoading(false);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция регистрации будет добавлена позже!", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowLoading(bool show)
        {
            loadingBorder.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
            btnLogin.IsEnabled = !show;
            txtUsername.IsEnabled = !show;
            txtPassword.IsEnabled = !show;
        }

        private void ShowError(string message)
        {
            txtError.Text = message;
            errorBorder.Visibility = Visibility.Visible;
        }

        private void HideError()
        {
            errorBorder.Visibility = Visibility.Collapsed;
            txtError.Text = string.Empty;
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
                this.Close();
            base.OnKeyDown(e);
        }
    }
}