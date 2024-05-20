using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chemify.MVVM.View
{
    /// <summary>
    /// Interaction logic for TPQuiz.xaml
    /// </summary>
    public partial class InvelisQuiz : UserControl
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5 };
        int qnb = 0;
        int i;
        int score;

        public InvelisQuiz()
        {
            InitializeComponent();
            StartGame();
            NextQuestion();
        }

        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton= sender as Button;
            if (senderButton.Tag.ToString() == "1")
            {
                score++;
                senderButton.Background=Brushes.DarkGreen;
            }
            if (qnb < 0)
            {
                qnb = 0;
            }
            else
            {
                qnb++;
                senderButton.Background = Brushes.DarkRed;
                foreach (var x in myCanvas.Children.OfType<Button>())
                {
                    if (x.Tag.ToString() == "1") x.Background = Brushes.DarkGreen;
                }
            }
            ScoreText.Content = "Raspunsuri corecte" + score + "/" + questionNumbers.Count;
            
        }

        private void RestartGame()
        {
            score = 0;
            qnb = -1;
            i = 0;
            StartGame();
        }

        private void NextQuestion()
        {
            if(qnb<questionNumbers.Count)
            {
                i = questionNumbers[qnb];
            }
            else RestartGame();
            foreach(var x in myCanvas.Children.OfType<Button>())
            {
                x.Tag = "0";
                x.Background = Brushes.MintCream;
            }
            
            switch(i)
            {
                case 1:

                    txtQuestion.Text = "Ce reprezintă învelișul de electroni?";
                    ans1.Content = "Totalitatea protonilor din nucleul atomului.";
                    ans2.Content = "Totalitatea electronilor care gravitează în jurul nucleului.";
                    ans3.Content = "Totalitatea neutronilor din atom.";
                    ans2.Tag = "1";

                    break;

                case 2:

                    txtQuestion.Text = "Cum sunt organizați electronii în învelișul de electroni?";
                    ans1.Content = "Aleatoriu, fără o ordine specifică.";
                    ans2.Content = "Pe straturi, substrauri și orbitali.";
                    ans3.Content = "Doar pe straturi.";
                    ans2.Tag = "1";

                    break;

                case 3:

                    txtQuestion.Text = "Care sunt caracteristicile orbitalului de tip s?";
                    ans1.Content = "Are o formă sferică și există câte unul în fiecare substrat.";
                    ans2.Content = "Are o formă dublu-lobată și există câte trei în fiecare substrat.";
                    ans3.Content = "Are o formă complexă și există câte cinci în fiecare substrat.";
                    ans1.Tag = "1";

                    break;

                case 4:

                    txtQuestion.Text = "Câți electroni poate găzdui un orbital de tip p?";
                    ans1.Content = "2 electroni";
                    ans2.Content = "6 electroni";
                    ans3.Content = "10 electroni";
                    ans2.Tag = "1";

                    break;

                case 5:

                    txtQuestion.Text = "Care sunt caracteristicile orbitalilor de tip f?";
                    ans1.Content = "Au forme sferice și există câte unu în fiecare substrat.";
                    ans2.Content = "Au forme complexe și sunt câte 7 în fiecare substrat.";
                    ans3.Content = "Au forme complexe și sunt câte 3 în fiecare substrat.";
                    ans2.Tag = "1";

                    break;
            }

        }

        private void StartGame()
        {
            var randomList=questionNumbers.OrderBy(a=>Guid.NewGuid()).ToList();
            questionNumbers = randomList;
            
        }

        private void nextQuestion(object sender, RoutedEventArgs e)
        {
            NextQuestion();
        }
    }
}
