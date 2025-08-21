using System.Windows;
using System.Windows.Controls;

namespace PV_app.Views
{
    public partial class LoginView : Window
    {
        public Visibility ErrorMessageVisibility { get; set; } = Visibility.Collapsed;
        public string ErrorMessageText { get; set; }

        public LoginView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            bool isUsernameValid = true;
            bool isPasswordValid = true;

            if (string.IsNullOrEmpty(username))
            {
                ErrorMessageText = "El campo usuario no puede estar vacío.";
                ErrorMessageVisibility = Visibility.Visible;
                isUsernameValid = false;
            }

            if (string.IsNullOrEmpty(password))
            {
                ErrorMessageText = "El campo contraseña no puede estar vacío.";
                ErrorMessageVisibility = Visibility.Visible;
                isPasswordValid = false;
            }

            if (username.Length < 5 || username.Length > 10)
            {
                ErrorMessageText = "El usuario debe tener entre 5 y 10 caracteres.";
                ErrorMessageVisibility = Visibility.Visible;
                isUsernameValid = false;
            }

            if (password.Length < 5 || password.Length > 10)
            {
                ErrorMessageText = "La contraseña debe tener entre 5 y 10 caracteres.";
                ErrorMessageVisibility = Visibility.Visible;
                isPasswordValid = false;
            }

            if (isUsernameValid && isPasswordValid)
            {
                using (var context = new AppDbContext())
                {
                    var user = context.GetUser(username, password);

                    if (user != null)
                    {
                        MessageBox.Show($"Bienvenido, {user.firstName}!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        ErrorMessageText = "Usuario o contraseña incorrectos.";
                        ErrorMessageVisibility = Visibility.Visible;
                    }
                }
            }

            ErrorMessage.Text = ErrorMessageText;
            ErrorMessage.Visibility = ErrorMessageVisibility;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) 
        {
            Application.Current.Shutdown();
        }
    }
}
