using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace PhoneWeb.Models
{
    public class Division
    {
        public string Name { get; set; }
        public List<string> Bureaus { get; set; }
    }

    public class Divisions
    {
        public List<Division> GetSubdivisions(string path = null)
        {

            List<Division> listSubdivisions = new List<Division>();
            XmlDocument document = new XmlDocument();
            // /App_Data/bureau.xml
            if (path == null) document.Load(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\bureau.xml"); //document.Load("bureau.xml");
            else document.Load(path);

            XmlNode root = document.DocumentElement; // Все
            if (root == null) throw new FileLoadException("Ошибка загрузки файла со списком производств и бюро");

            foreach (XmlNode sub in root.ChildNodes)
            {
                Division sd = new Division();
                sd.Name = sub.Name.Replace('_', ' ');
                sd.Bureaus = new List<string>();

                foreach (XmlNode bureau in sub.ChildNodes)
                {
                    sd.Bureaus.Add(bureau.InnerText);
                }
                listSubdivisions.Add(sd);
            }
            return listSubdivisions;
        }
    }
}