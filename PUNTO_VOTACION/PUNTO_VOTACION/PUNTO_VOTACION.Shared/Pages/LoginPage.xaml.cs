
using PUNTO_VOTACION.Helpers;
using PUNTO_VOTACION.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace PUNTO_VOTACION.Pages
{

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            EmailTextBox.Text = "katecastano255600@correo.itm.edu.co";


        }        
        private async void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            
            Response response = await ApiService.RestoreAsync(new LoginRequest
            {
                Email = EmailTextBox.Text,
            });
            MessageDialog messageDialog;
            if (!response.IsSuccess)
            {
                messageDialog = new MessageDialog(response.Message, "Error");
                await messageDialog.ShowAsync();
                return;
            }

            messageDialog = new MessageDialog("Se ha enviado un correo electronico para restablecer su cuenta", "Recuperar contraseña");
            await messageDialog.ShowAsync();
        }


        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = await ValidForm();
            if (!isValid)
            {
                return;
            }

            Response response = await ApiService.LoginAsync(new LoginRequest
            {
                Email = EmailTextBox.Text,
                Password = PasswordPasswordBox.Password
            });

            TokesResponse responseLogin = (TokesResponse)response.Result;

            MessageDialog messageDialog;
            if (!response.IsSuccess)
            {
                messageDialog = new MessageDialog(response.Message, "Error");
                await messageDialog.ShowAsync();
                return;
            }
            

            Frame.Navigate(typeof(MainPage), responseLogin);
        }

        private async Task<bool> ValidForm()
        {
            MessageDialog messageDialog;
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                messageDialog = new MessageDialog("Debes ingresar tu email.", "Error");
                await messageDialog.ShowAsync();
                return false;
            }
            if (!RegexUtilities.IsValidEmail(EmailTextBox.Text))
            {
                messageDialog = new MessageDialog("Debes ingresar un email válido.", "Error");
                await messageDialog.ShowAsync();
                return false;
            }
            if (PasswordPasswordBox.Password.Length < 6)
            {
                messageDialog = new MessageDialog("Debes ingresar tu contraseña de al menos seis (6) carátertes.", "Error");
                await messageDialog.ShowAsync();
                return false;
            }
            return true;
        }



    }
}
