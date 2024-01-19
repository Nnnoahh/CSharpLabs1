using Labs1Task3;
using System.Xml;

public static class XmlParser
{
    public static Log Parse(string xml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);

        Log log = new Log();

        XmlNodeList eventNodes = xmlDoc.SelectNodes("//event");

        foreach (XmlNode eventNode in eventNodes)
        {
            Event evnt = new Event();

            evnt.Date = DateTime.Parse(eventNode.Attributes["date"].Value.Trim());
            evnt.Result = eventNode.Attributes["result"].Value.Trim();
            evnt.IpFrom = eventNode.SelectSingleNode("ip-from").InnerText.Trim();
            evnt.Method = eventNode.SelectSingleNode("method").InnerText.Trim();
            evnt.UrlTo = eventNode.SelectSingleNode("url-to").InnerText.Trim();
            evnt.Response = int.Parse(eventNode.SelectSingleNode("response").InnerText.Trim());

            log.Events.Add(evnt);
        }

        return log;
    }
}
