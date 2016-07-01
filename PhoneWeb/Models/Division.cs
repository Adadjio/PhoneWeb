using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PhoneWeb.Models
{
    public class Division
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<string> Bureaus { get; set; }
    }

    public class Divisions:List<Division>
    {
        public Division this[string name]
        {
            get
            {
                return this.Find(x => x.Name == name);
            }
            set
            {
                var index = this.FindIndex(x => x.Name == name);
                this[index] = value;
            }
        }
    }
}