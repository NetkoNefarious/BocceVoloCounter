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
        private TimeSpan DefaultTimer { get; set; }
        public TimeSpan setTimer;
        public bool isAlive = false;
        private DispatcherTimer DispatcherTimerInstance { get; set; }

        // Constructiors
        public Timer(int minutes = 0, int seconds = 0)
        {
            DefaultTimer = setTimer = new TimeSpan(0, minutes, seconds);


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
            isAlive = true;
        }

        public void Stop()
        {
            DispatcherTimerInstance.Stop();
            isAlive = false;
        }

        internal void Reset()
        {
            setTimer = DefaultTimer;
        }

        internal void SetUp()
        {
            SetUpTimer setUpTimerWindow = new SetUpTimer();
            setUpTimerWindow.Show();
        }
    }
}
