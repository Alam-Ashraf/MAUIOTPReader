using CommunityToolkit.Mvvm.Messaging;
using static System.Net.WebRequestMethods;

namespace MAUIOTPReader;

public partial class MainPage : ContentPage
{
    #region Constructor
    public MainPage()
    {
        InitializeComponent();

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            _ = CheckPermissionAvail();
            WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) =>
            {
                OnMessageReceived(m.OTP);
            });
        }
    }
    #endregion

    #region Permission
    private async Task CheckPermissionAvail()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.Sms>();

        if (status == PermissionStatus.Granted)
        {
            // Permission has already been granted
        }
        else if (status == PermissionStatus.Denied)
        {
            // Permission has been denied
            // You may want to show a message explaining why you need the permission
            await RequestPermission();
        }
        else
        {
            await RequestPermission();
        }
    }

    private async Task RequestPermission()
    {
        // Permission has not been requested yet
        var requestResult = await Permissions.RequestAsync<Permissions.Sms>();

        if (requestResult == PermissionStatus.Granted)
        {
            // Permission granted
        }
        else
        {
            // Permission denied
            // You may want to show a message explaining why you need the permission
        }
    }
    #endregion

    #region Android Msg Received
    private void OnMessageReceived(string message)
    {
        AutoFillEntry.Text = message;
    }
    #endregion
}

public class MyMessage
{
    public string OTP { get; set; }

    public MyMessage(string OTP)
    {
        this.OTP = OTP;
    }
}