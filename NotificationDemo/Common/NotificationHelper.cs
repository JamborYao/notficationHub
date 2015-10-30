using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.IO;
using Windows.UI.Xaml.Controls;

namespace NotificationDemo.Common
{
    public class NotificationHelper
    {
        public NotificationHelper(Frame frame)
        {
            this.frame = frame;
        }
        public  Frame frame;
        //toast notification
        #region
        public  string ToastXMLContent { get; set; }

        public  void SendToastNotification()
        {
            XmlDocument toastXML = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);
            (toastXML.GetElementsByTagName("image")[0] as XmlElement).SetAttribute("src","/Assets/arrow.PNG");
            toastXML.GetElementsByTagName("text")[0].InnerText="this is a test message";
            toastXML.GetElementsByTagName("text")[1].InnerText = "line 2 this is a test message";
            ConvertXMLDocumenttoString(toastXML);
          

            ToastNotification toast = new ToastNotification(toastXML);
           
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public  void SendToastDefineXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ToastXMLDefine);
            ToastNotification toast = new ToastNotification(xmlDoc);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
            toast.Activated += Toast_Activated;
        }

        private  void Toast_Activated(ToastNotification sender, object args)
        {
            var content = ((Windows.UI.Notifications.ToastActivatedEventArgs)args).Arguments;
            ToastArgs = content;
            switch (ToastArgs.Split('.')[0])
            {
                case "About":
                    this.frame.Navigate(typeof(About));
                    break;
                default:
                    break;
            }
        }
        #endregion
        public  string ToastArgs { get; set; }

        //public
        #region
        public  void  ConvertXMLDocumenttoString(XmlDocument xmlDoc)
        {
           ToastXMLContent = xmlDoc.GetXml();
           
           var content= xmlDoc.InnerText;
           
        }
        #endregion

        public    string ToastXMLDefine = "" +
                                                    "<toast launch=\"/About.xaml\"> " +
                                        "    <visual>" +
                                        "        <binding template=\"ToastImageAndText02\">" +
                                        "            <image id=\"1\" src=\"/Assets/arrow.PNG\"/>"+
                                        "            <text id=\"1\">this is a test message</text>"+
                                        "            <text id=\"2\">line 2 this is a test message</text>"+
                                        "        </binding>"+
                                        "    </visual>"+
                                        "    </toast>";
    }
}
