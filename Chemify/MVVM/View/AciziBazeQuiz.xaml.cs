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
    public partial class AciziBazeQuiz : UserControl
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5 };
        int qnb = 0;
        int i;
        int score;

        public AciziBazeQuiz()
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

                    txtQuestion.Text = "Care este diferența principală între hidracizi și oxiacizi?";
                    
                    ans1.Content = new TextBlock { Inlines = { "Hidracizii conțin un nemetal, în timp ce", new LineBreak(), "oxiacizii conțin un nemetal și oxigen." } };
                    ans2.Content = "Hidracizii sunt acizi slabi, în timp ce oxiacizii sunt acizi tari.";
                    
                    ans3.Content = new TextBlock { Inlines = { "Hidracizii sunt utilizați în industria alimentară, în timp ce oxiacizii sunt", new LineBreak(), "utilizați în industria chimică." } };
                    ans1.Tag = "1";
                   

                    break;

                case 2:

                    txtQuestion.Text = "Care dintre următoarele substanțe este un exemplu de hidracizi?";
                    ans1.Content = "H2SO4";
                    ans2.Content = "Ca(OH)2";
                    ans3.Content = "HCl";
                    ans3.Tag = "1";

                    break;

                case 3:

                    txtQuestion.Text = "Ce substanță chimică este cunoscută sub numele de \"sodă caustică\"?";
                    ans1.Content = "H₂SO₄";
                    ans2.Content = "NaOH";
                    ans3.Content = "HNO₃";
                    ans2.Tag = "1";

                    break;

                case 4:

                    txtQuestion.Text = "Care dintre următoarele nu este o utilizare a hidroxidului de sodiu?";
                    ans1.Content = "Sinteza explozivilor";
                    ans2.Content = "Mercerizarea bumbacului";
                    ans3.Content = "Obținerea săpunului și a detergenților";
                    ans1.Tag = "1";

                    break;

                case 5:

                    txtQuestion.Text = "Care dintre următoarele afirmații este adevărată despre acizi tari?";
                    ans1.Content = "Cedează protoni foarte greu";
                    ans2.Content = "Sunt parțial ionizați în soluție apoasă";
                    ans3.Content = "Cedează protoni foarte ușor";
                    ans3.Tag = "1";

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
