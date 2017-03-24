﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlarmPlus.GUI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAlarm : ContentPage
    {
        public NewAlarm()
        {
            InitializeComponent();
            InitializeUIComponents();
        }

        private void InitializeUIComponents()
        {
            WeekDay.IsVisible = AlarmRepeatStatus.On;
            //RepeatitionWeeks.IsVisible = AlarmRepeatStatus.On;
            //WeeksLabel.Text = WeeksOfRepeatition.Text.Equals("1") ? "week" : "weeks";
            Nagging.IsVisible = NaggingStatus.On;
        }

        private void RepeatStatusChanged(object sender, EventArgs e)
        {
            WeekDay.IsVisible = AlarmRepeatStatus.On;
            //RepeatitionWeeks.IsVisible = AlarmRepeatStatus.On;
        }

        //private void WeekRepeatEntered(object sender, EventArgs e)
        //{
        //    WeeksLabel.Text = WeeksOfRepeatition.Text.Equals("1") ? "week" : "weeks";
        //}

        private void NaggingStatus_OnChanged(object sender, ToggledEventArgs e)
        {
            Nagging.IsVisible = NaggingStatus.On;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }
    }
}
