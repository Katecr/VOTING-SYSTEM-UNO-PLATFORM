using PUNTO_VOTACION.Helpers;
using PUNTO_VOTACION.Models;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;



namespace PUNTO_VOTACION.Pages
{

    public sealed partial class MainPage : Page
    {
        private static MainPage _instance;

        public MainPage()
        {
            InitializeComponent();
            _instance = this;
        }

        public TokenResponse TokenResponse { get; set; }

        public static MainPage GetInstance()
        {
            return _instance;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TokenResponse = (TokenResponse)e.Parameter;
            WelcomeTextBlock.Text = $"Bienvenid@: {TokenResponse.User.Name}";
            LoadPageQuestionAsync(TokenResponse.Token);
            
        }

        private async void LoadPageQuestionAsync(string token)
        {
            Response response = await ApiService.QuestionAsync(token);

            if (response.IsSuccess)
            {
                Question responseQuestion = (Question)response.Result;
                MyFrame.Navigate(typeof(QuestionsPage), responseQuestion);
            }
            else
            {

                MessageDialog messageDialog;
                messageDialog = new MessageDialog(response.Message, "Error");
                await messageDialog.ShowAsync();
                MyFrame.Navigate(typeof(CancelVotePage));

            }

        }
    }
}
