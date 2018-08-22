using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class BoxerStats
    {
        public BoxerCharcs bc;
        public BoxerStats()
        {
            bc = new BoxerCharcs();
        }
        public int HP { get { return bc.HP; } set { bc.HP = value; } }
        public int Stunning { get { return bc.Stunning; } set { bc.Stunning = value; } }
        public int Deffence { get { return bc.Deffence; } set { bc.Deffence = value; } }
        public int MaxHP;
        public int Power;
        public int Speed;
        public int Block;
    }
}
