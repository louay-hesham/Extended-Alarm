
using Android.Content;
using Android.Widget;
using AlarmPlus.Core;
using Newtonsoft.Json;
using Android.Media;
using static Android.Provider.MediaStore.Audio;

namespace AlarmPlus.Droid
{
    [BroadcastReceiver]
    class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Alarm Fired!!", ToastLength.Long).Show();
            int alarmID  = int.Parse(intent.GetStringExtra("AlarmID"));

            App.FiredAlarmID = alarmID;

            AudioManager audio = (AudioManager)context.GetSystemService(Context.AudioService);
            audio.SetStreamVolume(Stream.Music, audio.GetStreamMaxVolume(Stream.Music), VolumeNotificationFlags.Vibrate);

            Intent applicationIntent = new Intent(context, typeof(MainActivity));
            applicationIntent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(applicationIntent);
        }
    }
}