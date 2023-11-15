using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIOTPReader.Platforms.Droid.Handlers
{
    public class AutoFillEntryHandler : EntryHandler
    {
        protected override void ConnectHandler(AppCompatEditText platformView)
        {
            base.ConnectHandler(platformView);
            platformView.SetBackgroundColor(Android.Graphics.Color.LightGray);
        }
    }
}
