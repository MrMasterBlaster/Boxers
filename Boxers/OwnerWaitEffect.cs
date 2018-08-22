using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class OwnerWaitEffect : Effect, IEffect
    {
        int value;

        public OwnerWaitEffect(BoxerStats _bstats, int _time, int _value, Boxer owner)
        {
            value = _value;
            bstats = _bstats;
            time = _time;
            owner.EffectsPool.AddEffect(new HealEffect(bstats, bstats.Speed, 1));
        }
        public override void ChangeBlock()
        {
            
        }

        public override void ChangeHP()
        {
            
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
            ChangeStunning();
        }

        public override void ChangeStunning()
        {
            bstats.Stunning = time;
        }

        public override bool IsDone()
        {
            if (time == 0)
            {
                bstats.Stunning = 0;
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
