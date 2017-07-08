﻿using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlarmPlus.Core
{
    public class Database
    {

        private static SQLiteConnection connection;

        public static void InitializeDatabase()
        {
            connection = new SQLiteConnection(App.DatabasePlatform, DependencyService.Get<IFileHelper>().GetLocalFilePath("Database.db3"));
            connection.CreateTable<Alarm>();
            connection.CreateTable<SelectedDays>();
        }

        //Alarms operations
        public static List<Alarm> GetAlarms()
        {
            return connection.Table<Alarm>().ToList();
        }

        public static Alarm GetAlarm(int id)
        {
            return connection.Table<Alarm>().Where(i => i.ID == id).FirstOrDefault();
        }

        public static int SaveAlarm(Alarm item)
        {
            if (item.ID != 0)
            {
                return connection.Update(item);
            }
            else
            {
                return connection.Insert(item);
            }
        }

        public static int DeleteAlarm(Alarm item)
        {
            return connection.Delete(item);
        }

        //SelectedDays operations
        public static SelectedDays GetSelectedDays(int id)
        {
            return connection.Table<SelectedDays>().Where(i => i.ID == id).FirstOrDefault();
        }

        public static int SaveSelectedDays(SelectedDays item)
        {
            if (item.ID != 0)
            {
                return connection.Update(item);
            }
            else
            {
                return connection.Insert(item);
            }
        }

        public static int DeleteSelectedDays(SelectedDays item)
        {
            return connection.Delete(item);
        }
    }
}