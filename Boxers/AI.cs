using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boxers.Game1;

namespace Boxers
{
    class AI
    {
        List<Condition> conditions;
        Boxer owner;
        Boxer enemy;
        Array states;
        List<boxerAction> actions;
        public Condition controlValue;


        public AI(Boxer _owner)
        {
            owner = _owner;

            conditions = new List<Condition>();
            states = Enum.GetValues(typeof(BoxerStates));
            actions = new List<boxerAction>();

            actions.Add(new boxerAction(owner.Hit));
            actions.Add(new boxerAction(owner.Block));
            actions.Add(new boxerAction(owner.Wait));
        }

        public void SelectEnemy(Boxer _enemy)
        {
            enemy = _enemy;
        }

        public void DoAction()
        {
            boxerAction ba = null;
            foreach (var cond in conditions)
            {
                ba = cond.GetAction(enemy.bs.BS);
                controlValue = cond;
            }
            if (ba == null)
            {
                CreateNewCondition();
                controlValue = null;
            }
            else
            {
                ba.Invoke();
            }
        }

        public void CreateNewCondition()
        {
            Random random = new Random();
            Random random1 = new Random(random.Next());
            Condition cond = new Condition((BoxerStates)states.GetValue(random.Next(states.Length)), actions.ElementAt(random1.Next(actions.Count)));
            if (conditions.Count == 0)
            {
                conditions.Add(cond);
            }


            //while (conditions.IndexOf(cond) != -1)
            
            while (IsExistCondition(cond))
            {
                random = new Random(random1.Next());
                random1 = new Random(random.Next());
                cond = new Condition((BoxerStates)states.GetValue(random.Next(states.Length)), actions.ElementAt(random1.Next(actions.Count)));
            }
            conditions.Add(cond);
        }
        
        bool IsExistCondition(Condition cond)
        {
            foreach (var c in conditions)
            {
                if (cond.ba == c.ba && cond.bs == c.bs)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
