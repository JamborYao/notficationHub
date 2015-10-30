using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.IO;

namespace NotificationDemo.Common
{
    public class NotificationHelper
    {
        //toast notification
        #region
        public static string ToastXMLContent { get; set; }

        public static void SendToastNotification()
        {
            XmlDocument toastXML = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);
            (toastXML.GetElementsByTagName("image")[0] as XmlElement).SetAttribute("src","/Assets/arrow.PNG");
            toastXML.GetElementsByTagName("text")[0].InnerText="this is a test message";
            toastXML.GetElementsByTagName("text")[1].InnerText = "line 2 this is a test message";
            ConvertXMLDocumenttoString(toastXML);
          

            ToastNotification toast = new ToastNotification(toastXML);
           
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        #endregion

        //public
        #region
        public static void  ConvertXMLDocumenttoString(XmlDocument xmlDoc)
        {
           ToastXMLContent = xmlDoc.GetXml();
           
           var content= xmlDoc.InnerText;
           
        }
        #endregion

    }
}
