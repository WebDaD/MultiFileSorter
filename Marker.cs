using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Xml.Serialization;

namespace MultiFileSorter
{
    [Serializable]
    [XmlRoot(ElementName = "Marker", IsNullable = false)]
    public class Marker
    {
        private char key;
        private string folder;
        private int color_r;
        private int color_g;
        private int color_b;
        private int id;
        public Marker(int id, char key, string folder, int color_r, int color_g,int color_b)
        {
            this.id = id;
            this.key = key;
            this.folder = folder;
            this.color_r = color_r;
            this.color_g = color_g;
            this.color_b = color_b;
        }

        public Marker()
        {

        }

        [XmlAttribute(AttributeName = "ID")]
        public int ID { get { return id; } set{id=value;} }

        [XmlAttribute(AttributeName = "Key")]
        public char Key { get { return key; } set { key = value; } }

        [XmlAttribute(AttributeName = "Folder")]
        public string Folder { get { return folder; } set { folder = value; } }

         [XmlAttribute(AttributeName = "Color_R")]
        public int Color_R { get { return color_r; } set { color_r = value; } }

         [XmlAttribute(AttributeName = "Color_G")]
         public int Color_G { get { return color_g; } set { color_g = value; } }

         [XmlAttribute(AttributeName = "Color_B")]
         public int Color_B { get { return color_b; } set { color_b = value; } }

        public Color Color { get { return Color.FromArgb(color_r,color_g,color_b); }}
    }
}
