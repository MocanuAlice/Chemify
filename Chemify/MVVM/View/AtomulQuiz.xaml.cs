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
    public partial class AtomulQuiz : UserControl
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5 };
        int qnb = 0;
        int i;
        int score;

        public AtomulQuiz()
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
            }
            ScoreText.Content = "Raspunsuri corecte" + score + "/" + questionNumbers.Count;
            NextQuestion();
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
                x.Background = Brushes.Bisque;
            }
            
            switch(i)
            {
                case 1:

                    txtQuestion.Text = "Ce este un atom?";
                    ans1.Content = "Cea mai mică particulă dintr-o substanță care poate fi divizată prin procedee chimice obișnuite.";
                    ans2.Content = "Cea mai mică particulă dintr-o substanță care nu mai poate fi divizată prin procedee chimice obișnuite.";
                    ans3.Content = "O particulă subatomică ce conține protoni și neutroni.";
                    ans2.Tag = "1";

                    break;

                case 2:

                    txtQuestion.Text = "Ce reprezintă numărul atomic (Z) al unui atom?";
                    ans1.Content = "Numărul total de protoni și neutroni din nucleu.";
                    ans2.Content = "Numărul de neutroni din nucleu.";
                    ans3.Content = "Numărul de protoni din nucleu și numărul de electroni din învelișul electronic.";
                    ans3.Tag = "1";

                    break;

                case 3:

                    txtQuestion.Text = "Ce indică numărul de masă (A) al unui atom?";
                    ans1.Content = "Numărul de protoni din nucleu.";
                    ans2.Content = "Numărul de electroni din învelișul electronic.";
                    ans3.Content = "Suma dintre numărul de protoni și numărul de neutroni din nucleu.";
                    ans3.Tag = "1";

                    break;

                case 4:

                    txtQuestion.Text = "Ce sarcină electrică au protonii și electronii dintr-un atom?";
                    ans1.Content = "Protonii au sarcină negativă, iar electronii au sarcină pozitivă.";
                    ans2.Content = "Protonii au sarcină pozitivă, iar electronii au sarcină negativă.";
                    ans3.Content = "Atât protonii, cât și electronii au sarcină neutru.";
                    ans2.Tag = "1";

                    break;

                case 5:

                    txtQuestion.Text = "Unde se găsesc protonii și neutronii într-un atom?";
                    ans1.Content = "În învelișul electronic.";
                    ans2.Content = "În nucleul atomului.";
                    ans3.Content = "În afara nucleului atomului.";
                    ans2.Tag = "1";

                    break;
            }

        }

        private void StartGame()
        {
            var randomList=questionNumbers.OrderBy(a=>Guid.NewGuid()).ToList();
            questionNumbers = randomList;
            for(int i = 0; i < questionNumbers.Count; i++)
            {

            }
        }
    }
}
