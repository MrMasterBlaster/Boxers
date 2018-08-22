using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class BoxerStatsFactory
    {
        public BoxerStatsFactory()
        {

        }

        public BoxerStats GetStandart()
        {
            BoxerStats bs = new BoxerStats();
            bs.Block = 5;
            bs.HP = 300;
            bs.MaxHP = 300;
            bs.Power = 10;
            bs.Speed = 20;
            return bs;
        }
    }
}
