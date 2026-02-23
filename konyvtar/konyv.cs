using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    public class Konyv
    {
        public string cim { get; set; }
        public List<string> szerzok { get; set; }
        public Kiado kiado { get; set; }
        public int oldalszam { get; set; }
        public List<string> kategoriak { get; set; }
        public int ar { get; set; }
        public bool elkeszult { get; set; }
    }
}
