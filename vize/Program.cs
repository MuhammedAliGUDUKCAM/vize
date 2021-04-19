using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace vize
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument ahaberXml = new XmlDocument();
            XmlDocument XmlBenim = new XmlDocument();

            XmlBenim.Load("ahaber.xml");

            XElement root = XElement.Load("ahaber.xml");

            ahaberXml.Load("https://www.ahaber.com.tr/rss/anasayfa.xml");


            root.RemoveAll();

            foreach (XmlNode item in ahaberXml.SelectNodes("rss/channel/item"))
            {
                Console.WriteLine(item["title"].InnerText);

                XElement medya = new XElement("medya");
                XElement title = new XElement("title");

                title.Value = item["title"].InnerText;

                medya.Add(title);
                root.Add(medya);

            }


            root.Save("ahaber.xml");

            Console.ReadKey();

        }
    }
}
