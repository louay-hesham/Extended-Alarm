﻿using AlarmPlus.Core;
using Newtonsoft.Json;
using PCLStorage;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlarmPlus
{
    public partial class App : Application
    {
        private static App Instance = null;

        public static NavigationPage NavPage;

        public static Settings AppSettings { get; set; }

        public static new App Current
        {
            get
            {
                if (Instance == null) Instance = new App();
                return Instance;
            }
        }

        public static ISQLitePlatform DatabasePlatform
        {
            get
            {
                return DependencyService.Get<IDatabasePlatformPicker>().GetPlatform();
            }
        }

        public static IRingtoneManager RingtoneManager
        {
            get
            {
                return DependencyService.Get<IRingtoneManager>();
            }
        }

        public static IAppMinimizer AppMinimizer
        {
            get
            {
                return DependencyService.Get<IAppMinimizer>();
            }
        }

        public static IAlarmSetter AlarmSetter
        {
            get
            {
                return DependencyService.Get<IAlarmSetter>();
            }
        }

        public static void SaveAlarms()
        {
            foreach (Alarm alarm in Alarm.Alarms)
            {
                Database.SaveAlarm(alarm);
            }
        }

        public static void LoadAlarms()
        {
            var loadedAlarms = Database.GetAlarms();
            foreach (Alarm alarm in loadedAlarms)
            {
                Alarm.Alarms.Add(alarm);
            }   
        }

        public static async Task SaveAppSettings()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFile file = await rootFolder.CreateFileAsync("Settings", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(AppSettings));
        }

        public static void LoadAppSettings()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            var x = rootFolder.CheckExistsAsync("Settings").Result;
            if (x.Equals(ExistenceCheckResult.FileExists))
            {
                IFile file = rootFolder.GetFileAsync("Settings").Result;
                if (file != null)
                {
                    string serializedSettings = file.ReadAllTextAsync().Result;
                    if (serializedSettings != null && !serializedSettings.Equals(string.Empty))
                    {
                        AppSettings = JsonConvert.DeserializeObject<Settings>(serializedSettings);
                    }
                    else
                    {
                        AppSettings = new Settings("2", "1", "10", "10");
                    }
                }
            }
            else
            {
                AppSettings = new Settings("2", "1", "10", "10");
            }
        }

        public App()
        {
            Database.InitializeDatabase();
            LoadAppSettings();
            LoadAlarms();
            InitializeComponent();
            NavPage = new NavigationPage();
            MainPage = NavPage;
            NavPage.Navigation.PushAsync(new GUI.MainTabbedPage(), true);
        }

        protected override void OnStart()
        {

        }

        protected async override void OnSleep()
        {
            SaveAlarms();
            await SaveAppSettings();
        }

        protected override void OnResume()
        {
            
        }
    }
}
