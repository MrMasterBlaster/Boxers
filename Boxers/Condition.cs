using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boxers.Game1;

namespace Boxers
{
    class Condition
    {
        public int weigth = 0;
        public BoxerStates bs;
        public boxerAction ba;

        public Condition(BoxerStates _bs, boxerAction _ba)
        {
            bs = _bs;
            ba = _ba;
        }

        public bool GetAnswer(BoxerStates _bs)
        {
            if (bs == _bs)
            {
                return true;
            }
            return false;
        }

        public boxerAction GetAction(BoxerStates _bs)
        {
            if (GetAnswer(_bs))
            {
                return ba;
            }
            return null;
        }
    }
}
