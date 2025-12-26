using Android.OS;
using Android.Runtime;
using CommunityToolkit.Mvvm.Messaging;
using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.Platforms.Android
{
    public class MyTimer : CountDownTimer
    {
        public MyTimer(long millisInFuture, long countDownInterval) : base(millisInFuture, countDownInterval)
        {
            Start();
        }
        public override void OnFinish()
        {
            WeakReferenceMessenger.Default.Send(new AppMessage<long>(Keys.FinishedSignal));
        }

        public override void OnTick(long millisUntilFinished)
        {
            WeakReferenceMessenger.Default.Send(new AppMessage<long>(millisUntilFinished));

        }
    }
}
