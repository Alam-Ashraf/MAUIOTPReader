using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIOTPReader.Platforms.iOS.Handlers
{
    public class AutoFillEntryHandler : EntryHandler
    {
        protected override void ConnectHandler(MauiTextField platformView)
        {
            base.ConnectHandler(platformView);

            platformView.BackgroundColor = UIKit.UIColor.LightGray;
        }
    }
}
