using PUNTO_VOTACION.Models;
using PUNTO_VOTACION.Helpers;
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;



namespace PUNTO_VOTACION.Pages
{

    public sealed partial class QuestionsPage : Page
    {
        public QuestionsPage()
        {
            InitializeComponent();
        }

        public Question Question { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            base.OnNavigatedTo(e);
            Question = (Question)e.Parameter;

            QuestionPage.Text = $"{Question.Description}";
            option1.Text = $"{Question.Options.ElementAt(0).Description}";
            option2.Text = $"{Question.Options.ElementAt(1).Description}";
            option3.Text = $"{Question.Options.ElementAt(2).Description}";
            option4.Text = $"{Question.Options.ElementAt(3).Description}";
            
        }

        private async void VoteOptionA_Click(object sender, RoutedEventArgs e)
        {


            Response response = await ApiService.SendVoteAsync(MainPage.GetInstance().TokenResponse.Token,
                 new Vote
                 {
                     QuestionId = Question.Id,
                     OptionId = "1",
                 });

            validateVote(response);

        }


        private async void VoteOptionB_Click(object sender, RoutedEventArgs e)
        {
            Response response = await ApiService.SendVoteAsync(MainPage.GetInstance().TokenResponse.Token,
                new Vote
                {
                    QuestionId = Question.Id,
                    OptionId = "2",
                });
            validateVote(response);
        }


        private async void VoteOptionC_Click(object sender, RoutedEventArgs e)
        {
            Response response = await ApiService.SendVoteAsync(MainPage.GetInstance().TokenResponse.Token,
                new Vote
                {
                    QuestionId = Question.Id,
                    OptionId = "3",
                });

            validateVote(response);
        }


        private async void VoteOptionD_Click(object sender, RoutedEventArgs e)
        {
            Response response = await ApiService.SendVoteAsync(MainPage.GetInstance().TokenResponse.Token,
                new Vote
                {
                    QuestionId = Question.Id,
                    OptionId = "4",
                });

            validateVote(response);


        }

        private async void validateVote(Response response)
        {
            if (response.IsSuccess)
            {
                MessageDialog messageDialog;
                messageDialog = new MessageDialog("Su voto ha sido registrado con exito", "OK");
                await messageDialog.ShowAsync();
                Frame.Navigate(typeof(LoginPage));

            }
        }
    }
}
