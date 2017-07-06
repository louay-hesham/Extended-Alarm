using System;
using AlarmPlus.Core;
using System.IO;
using Xamarin.Forms;
using AlarmPlus.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace AlarmPlus.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}