using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class OwnerHitEffect : Effect, IEffect
    {
        Boxer enemy;
        int timeToHit;

        public OwnerHitEffect(Boxer _enemy, BoxerStats _bstats, int _timeToHit, int _time)
        {
            enemy = _enemy;
            timeToHit = _timeToHit;
            time = _time;
            bstats = _bstats;
        }

        override public void ChangeBlock()
        {
            
        }

        override public void ChangeHP()
        {
            
        }

        override public void ChangeMaxHP()
        {
            
        }

        override public void ChangePower()
        {
            
        }

        override public void ChangeSpeed()
        {
            
        }

        override public void ChangeStats()
        {
            ChangeStunning();
        }
        override public void ChangeStunning()
        {
            bstats.Stunning = time;
        }

        override public bool IsDone()
        {
            if (time == 0)
            {
                bstats.Stunning = 0;
                return true;
            }
            return false;
        }

        void CreateHit()
        {
            enemy.EffectsPool.AddEffect(new DamageEffect(1, bstats.Power, enemy.boxerStats));
        }

        override public void Update()
        {
            ChangeStats();
            if (timeToHit == 0)
            {
                CreateHit();
            }
            time--;
            timeToHit--;
        }
    }
}
