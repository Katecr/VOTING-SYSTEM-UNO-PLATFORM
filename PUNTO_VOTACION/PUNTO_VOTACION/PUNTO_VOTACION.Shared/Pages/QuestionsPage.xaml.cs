using PUNTO_VOTACION.Models;
using PUNTO_VOTACION.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
    }
}
