using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using CommunityToolkit.Mvvm.Messaging;

namespace MAUIOTPReader;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static MainActivity Activity { get; private set; }
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Activity = this;

        // Register the SMS receiver
        RegisterReceiver(new SmsReceiver(), new IntentFilter(Telephony.Sms.Intents.SmsReceivedAction));
    }
}

[BroadcastReceiver(Enabled = true, Label = "SMS Receiver", Exported = true)]
[IntentFilter(new[] { Telephony.Sms.Intents.SmsReceivedAction })]
public class SmsReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        if (intent.Action == Telephony.Sms.Intents.SmsReceivedAction)
        {
            // Retrieve the SMS message
            var msgs = Telephony.Sms.Intents.GetMessagesFromIntent(intent);
            if (msgs != null && msgs.Length > 0)
            {
                var messageBody = msgs[0].MessageBody;

                System.Diagnostics.Debug.WriteLine("OTP Arrived : " + messageBody);

                // Sending OTP to MainPage
                WeakReferenceMessenger.Default.Send(new MyMessage(messageBody));
            }
        }
    }
}
