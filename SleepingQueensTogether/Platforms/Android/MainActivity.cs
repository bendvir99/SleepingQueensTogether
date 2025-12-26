using Android.App;
using Android.Content.PM;
using CommunityToolkit.Mvvm.Messaging;
using SleepingQueensTogether.Models;
using SleepingQueensTogether.Platforms.Android;

namespace SleepingQueensTogether
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        override protected void OnCreate(Android.OS.Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            WeakReferenceMessenger.Default.Register<AppMessage<TimerSettings>>(this, (r, m) =>
            {
                OnMessageReceived(m.Value);
            });
        }

        private static void OnMessageReceived(TimerSettings value)
        {
            _ = new MyTimer(value.TotalTimeInMilliseconds, value.IntervalInMilliseconds);
        }
    }
}
