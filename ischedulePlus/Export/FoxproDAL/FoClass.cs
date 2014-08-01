using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischedulePlus
{
    public class FoClass
    {
        public string DNO { get; set;}

        public string GRA { get; set;}

        public string CLA {　get; set;}

        public string TNO { get; set; }

        public string GNO { get; set; }

        public string ClassCode
        {
            get { return DNO.Trim() + GRA.Trim() + CLA.Trim(); } 
        }

        public string ClassName { get; set; }
    }
}