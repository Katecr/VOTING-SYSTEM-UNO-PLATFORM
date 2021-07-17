
using PUNTO_VOTACION.Helpers;
using PUNTO_VOTACION.Models;
using System;
using Windows.System;
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
            User user = (User)response.Result;
            if (user == null)
            {
                messageDialog = new MessageDialog("Usuario o contraseña incorrectos", "Error");
                await messageDialog.ShowAsync();
                return;
            }
        }
    }
}
