using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiFileSorter
{
    public class mFile
    {
        private Marker mark;
        private string file;

        public mFile(Marker m, string f)
        {
            mark = m;
            file = f;
        }

        public Marker Mark { get { return mark; } set { mark = value; } }
        public string File { get { return file; } set { file = value; } }
    }
}
