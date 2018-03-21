using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Threading;

namespace BocceVoloCounter
{
    class Timer
    {
        public TimeSpan setTimer;
        private DispatcherTimer DispatcherTimerInstance { get; set; }

        // Constructiors
        public Timer(int minutes = 0, int seconds = 0)
        {
            setTimer = new TimeSpan(0, minutes, seconds);

            DispatcherTimerInstance = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
        }

        public Timer(TimeSpan timeSpanValue)
        {
            setTimer = timeSpanValue;

            DispatcherTimerInstance = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (setTimer.Seconds == 0)
            {
                Stop();
                return;
            }

            setTimer.Subtract(new TimeSpan(0, 0, 1));
        }

        public void Start()
        {
            DispatcherTimerInstance.Tick += TimerTick;
            DispatcherTimerInstance.Start();
        }

        public void Stop()
        {
            DispatcherTimerInstance.Stop();
        }

        private void SetUp()
        {
            SetUpTimer setUpTimer = new SetUpTimer();
            setUpTimer.Show();
        }
    }
}
