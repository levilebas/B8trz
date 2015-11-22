using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace B8trz.Common
{
    public class TileHelper
    {
        public static void SetupTiles(int charge, int remaining)
        {
            string xml = "<tile>\n";
            xml += "<visual version=\"2\">\n";
            xml += "  <binding template=\"TileSquare150x150Text01\" fallback=\"TileSquareText01\">\n";
            xml += "      <text id=\"1\">Percentage</text>\n";
            xml += string.Format("      <text id=\"2\">{0}</text>\n", charge);
            //xml += "      <text id=\"3\">Row 2</text>\n";
            //xml += "      <text id=\"4\">Row 3</text>\n";
            xml += "  </binding>\n";
            xml += "  <binding template=\"TileWide310x150Text01\" fallback=\"TileWideText01\">\n";
            xml += "      <text id=\"1\">Minutes Remaining</text>\n";
            xml += string.Format("      <text id=\"2\">{0}</text>\n", remaining);
            //xml += "      <text id=\"3\">Wide Row 2</text>\n";
            //xml += "      <text id=\"4\">Wide Row 3</text>\n";
            xml += "  </binding>\n";
            xml += "</visual>\n";
            xml += "</tile>";
            XmlDocument txml = new XmlDocument();
            txml.LoadXml(xml);
            TileNotification tNotification = new TileNotification(txml);

            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tNotification);
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
