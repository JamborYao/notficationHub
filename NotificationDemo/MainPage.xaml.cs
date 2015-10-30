using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NotificationDemo.Common;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotificationDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public NotificationHelper notificationHelper;
        public MainPage()
        {
           
            this.InitializeComponent();
           
        }

        private void sendToast_click(object sender, RoutedEventArgs e)
        {
            notificationHelper = new NotificationHelper(this.Frame);
            notificationHelper.SendToastNotification();
            xmlContent.Text = notificationHelper.ToastXMLContent;
          
        }

        private void customSendToast_click(object sender, RoutedEventArgs e)
        {
            notificationHelper = new NotificationHelper(this.Frame);
           
            notificationHelper.ToastActiveEvent += ToastEvent;
            notificationHelper.SendToastDefineXML();
            var directPage= notificationHelper.ToastArgs;
           
            
        }
        public async void ToastEvent(string ToastArgs)
        {
            switch (ToastArgs.Split('.')[0].Substring(1))
            {
                case "About":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        this.Frame.Navigate(typeof(About));
                    });
                   
                    break;
                default:
                    break;
            }

        }
    }
}
