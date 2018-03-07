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
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += TimerTick;
            timer.Start();
        }

        void TimerTick(object sender, EventArgs e)
        {
            int seconds = int.Parse(timerBox.Text.Substring(timerBox.Text.Length - 2, 2)) - 1;
            timerBox.Text = (new TimeSpan(0, 0, seconds)).ToString(@"mm\:ss");
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Space:
                    scoreBox.Text = "1/1";
                    break;
            }
            Keyboard.Focus(hitButton);
        }
    }
}
