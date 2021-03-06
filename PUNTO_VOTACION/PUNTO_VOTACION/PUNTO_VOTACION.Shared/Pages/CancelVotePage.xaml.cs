using PUNTO_VOTACION.Helpers;
using PUNTO_VOTACION.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace PUNTO_VOTACION.Pages
{

    public sealed partial class CancelVotePage : Page
    {
        public CancelVotePage()
        {
            InitializeComponent();
        }

        private async void Cancel_ButtonClick(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await ConfirmDeleteAsync();



            if (result == ContentDialogResult.Primary)
            {
                Response response = await ApiService.CancelVoteAsync(MainPage.GetInstance().TokenResponse.Token);
                if (response.IsSuccess)
                {
                    MessageDialog messageDialog;
                    messageDialog = new MessageDialog("Su voto ha sido cancelado con exito", "OK");
                    await messageDialog.ShowAsync();
                    Frame.Navigate(typeof(LoginPage));
                }

            }
            else
            {
                return;
            }

        }

        private async Task<ContentDialogResult> ConfirmDeleteAsync()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "Confirmación",
                Content = "¿Estás seguro de cancelar el voto?",
                PrimaryButtonText = "Sí",
                CloseButtonText = "No"
            };

            return await confirmDialog.ShowAsync();
        }
    }
}
