using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class HealEffect : Effect, IEffect
    {
        int value;
        public HealEffect(BoxerStats _bstats, int _time, int _value)
        {
            value = _value;
            bstats = _bstats;
            time = _time;
        }

        public override void ChangeBlock()
        {
            
        }

        public override void ChangeHP()
        {
            if (bstats.HP + value <= bstats.MaxHP)
            {
                bstats.HP += value;
            }
            else
            {
                bstats.HP = bstats.MaxHP;
            }
        }

        public override void ChangeMaxHP()
        {
            
        }

        public override void ChangePower()
        {
            
        }

        public override void ChangeSpeed()
        {
            
        }

        public override void ChangeStats()
        {
            ChangeHP();
        }

        public override void ChangeStunning()
        {
            
        }

        public override bool IsDone()
        {
            if (time == 0)
            {
                return true;
            }
            return false;
        }

        public override void Update()
        {
            ChangeStats();
            time--;
        }
    }
}
