using System;
using Microsoft.Maui.Controls;

namespace BreakTimePro
{
    public partial class MainPage : ContentPage
    {
        private int _remainingTime = 0;
        private bool _isTimerRunning = false;

        public MainPage()
        {
            InitializeComponent();
            Title = "Break Time";
        }

        private void OnBreakButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var breakTime = int.Parse(button.Text.Replace("Take ", ""));

            _remainingTime = breakTime * 60; 
            _isTimerRunning = true;

            Dispatcher.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            if (_remainingTime > 0)
            {
                lblDisplay.Text = TimeSpan.FromSeconds(_remainingTime).ToString(@"mm\:ss");
                _remainingTime--;
            }
            else
            {
                _isTimerRunning = false;
                lblDisplay.Text = "Time is UP!!";
                ftmMain.Background = Colors.Red;

                return false;
            }

            return true;
        }
    }
}