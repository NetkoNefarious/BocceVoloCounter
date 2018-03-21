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

namespace BocceVoloCounter
{
    /// <summary>
    /// Interaction logic for SetUpTimer.xaml
    /// </summary>
    public partial class SetUpTimer : Window
    {
        public SetUpTimer()
        {
            InitializeComponent();
        }

        private void ButtonMinutesUp_Click(object sender, RoutedEventArgs e)
        {
            timerMinutes.Text = (int.Parse(timerMinutes.Text) + 1).ToString();
        }

        private void ButtonMinutesDown_Click(object sender, RoutedEventArgs e)
        {
            timerMinutes.Text = (int.Parse(timerMinutes.Text) - 1).ToString();
        }

        private void ButtonSecondsUp_Click(object sender, RoutedEventArgs e)
        {
            timerSeconds.Text = (int.Parse(timerSeconds.Text) + 1).ToString();
        }

        private void ButtonSecondsDown_Click(object sender, RoutedEventArgs e)
        {
            timerSeconds.Text = (int.Parse(timerSeconds.Text) - 1).ToString();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
