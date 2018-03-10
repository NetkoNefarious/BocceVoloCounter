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
        private TimeSpan Timer = new TimeSpan(0, 0, 10);
        private int hit;
        private Stack<bool> hitList = new Stack<bool>();

        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        public MainWindow()
        {
            InitializeComponent();
            timerBox.Text = Timer.ToString(@"mm\:ss");
        }

        void TimerTick(object sender, EventArgs e)
        {
            int seconds = int.Parse(timerBox.Text.Substring(timerBox.Text.Length - 2, 2)) - 1;
            timerBox.Text = (new TimeSpan(0, 0, seconds)).ToString(@"mm\:ss");
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Tick += TimerTick;
            timer.Start();
            timerBox.Background = Brushes.Red;
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timerBox.Background = Brushes.LightGray;
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Space:
                    break;
            }

            hitButton.Focus();
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            hit++;
            hitList.Push(true);
            UpdateScore();
        }

        private void MissedButton_Click(object sender, RoutedEventArgs e)
        {
            hitList.Push(false);
            UpdateScore();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (hitList.Count > 0)
            {
                if (hitList.Peek())
                    hit--;

                hitList.Pop();
                UpdateScore();
            }
        }

        private void CorrectButton_Click(object sender, RoutedEventArgs e)
        {
            if (hitList.Count > 0)
            {
                if (hitList.Peek())
                    hit--;
                else
                    hit++;

                hitList.Push(!hitList.Pop());
                UpdateScore();
            }
        }

        private void UpdateScore() => scoreBox.Text = String.Format("{0}/{1}", hit, hitList.Count);
    }
}
