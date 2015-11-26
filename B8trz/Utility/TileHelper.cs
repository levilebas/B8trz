using System.IO;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace B8trz.Utility
{
    public class TileHelper
    {
        public static void SetupTiles(int charge, string remaining)
        {
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);

            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);

            XmlNodeList tileTextAttributes = tileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = "Charge Level";
            tileTextAttributes[1].InnerText = charge.ToString();
            var tileNotification = new TileNotification(tileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            tileTextAttributes[0].InnerText = "Charge Remaining";
            tileTextAttributes[1].InnerText = remaining;
            tileNotification = new TileNotification(tileXml) {Tag = "timeRemaining"};
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

        public static void SetupBadge(int charge)
        {
            string badgeXmlString = string.Format("<badge value='{0}'/>", charge);
            Windows.Data.Xml.Dom.XmlDocument badgeDOM = new Windows.Data.Xml.Dom.XmlDocument();
            badgeDOM.LoadXml(badgeXmlString);
            BadgeNotification badge = new BadgeNotification(badgeDOM);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badge);
        }
    }
}
