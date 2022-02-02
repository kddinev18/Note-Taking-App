using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Note_Taking_App
{
    public class FileName
    {
        public FileName()
        {
            name = String.Empty;
        }
        public FileName(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
