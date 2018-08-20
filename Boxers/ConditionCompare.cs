using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class ConditionCompare: IComparer<Condition>
    {
        public int Compare(Condition cond1, Condition cond2)
        {
            return cond1.weigth == cond2.weigth ? 0 :
                (cond1.weigth < cond2.weigth ? 1 : -1);
        }
    }
}
