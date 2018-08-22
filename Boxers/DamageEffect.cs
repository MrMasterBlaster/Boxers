using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class DamageEffect: Effect, IEffect
    {
        int value;

        public DamageEffect(int _time, int _value, BoxerStats _bstats)
        {
            time = _time;
            value = _value;
            bstats = _bstats;
        }
        override public void ChangeStats()
        {
            ChangeHP();
        }

        override public void ChangeMaxHP() { }

        override public void ChangeHP()
        {
            bstats.HP -= value;
        }

        override public void ChangePower() { }

        override public void ChangeSpeed() { }

        override public void ChangeBlock() { }
        override public void ChangeStunning() { }

        public override bool IsDone()
        {
            if (time == 0)
            {
                return true;
            }
            return false;
        }

        override public void Update()
        {
            ChangeStats();
            time--;
        }
    }
}
