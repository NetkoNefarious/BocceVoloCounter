using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BocceVoloCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer timer;
        private Score score;

        public MainWindow()
        {
            InitializeComponent();
            score = new Score();
            timer = new Timer(0, 10);
            timerBox.Text = timer.setTimer.ToString(@"mm\:ss");
        }

        private void TimerButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "startButton":
                    timer.Start();
                    timerBox.Background = Brushes.Red;
                    break;
                case "stopButton":
                    timer.Stop();
                    timerBox.Background = Brushes.LightGray;
                    break;
                case "setTimerButton":
                    score.Remove();
                    break;
                case "resetTimerButton":
                    score.Correct();
                    break;
            }

            scoreBox.Text = score.UpdateScore();
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    break;
            }

            hitButton.Focus();
        }

        private void ScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch(button.Name)
            {
                case "hitButton":
                    score.Hit();
                    break;
                case "missButton":
                    score.Miss();
                    break;
                case "removeButton":
                    score.Remove();
                    break;
                case "correctButton":
                    score.Correct();
                    break;
            }

            scoreBox.Text = score.UpdateScore();
        }
    }
}
