using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    abstract class Effect: IEffect
    {
        public int time;
        protected BoxerStats bstats;

        abstract public void ChangeStats();

        abstract public void ChangeMaxHP();

        abstract public void ChangeHP();

        abstract public void ChangePower();

        abstract public void ChangeSpeed();

        abstract public void ChangeBlock();
        abstract public void ChangeStunning();

        abstract public bool IsDone();

        abstract public void Update();
    }
}
