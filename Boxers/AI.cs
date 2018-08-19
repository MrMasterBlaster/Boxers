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
        Random r;

        public AI(Boxer _owner)
        {
            owner = _owner;

            conditions = new List<Condition>();
            states = Enum.GetValues(typeof(BoxerStates));
            actions = new List<boxerAction>();

            actions.Add(new boxerAction(owner.Hit));
            actions.Add(new boxerAction(owner.Block));
            actions.Add(new boxerAction(owner.Wait));
            r = new Random();
        }

        public void SelectEnemy(Boxer _enemy)
        {
            enemy = _enemy;
        }

        public void DoAction()
        {
            boxerAction ba = null;
            if (r.Next(100) < 90)
            {
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
            else
            {
                CreateNewCondition();
                SortConditions();
            }
        }


        public void SortConditions()
        {
            List<Condition> newConditions = new List<Condition>();
            Condition minWeidthCond;
            for (int i = 0; i < conditions.Count; i++)
            {
                for (int j = 0; j < conditions.Count - 1; j++)
                {
                    if (conditions[j].weigth > conditions[j + 1].weigth)
                    {
                        minWeidthCond = conditions[j + 1];
                        conditions[j] = conditions[j + 1];
                        conditions[j + 1] = minWeidthCond;
                    }
                }
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
            int k = 0;
            while (IsExistCondition(cond) && k < 1000)
            {
                k++;
                random = new Random(random1.Next());
                random1 = new Random(random.Next());
                cond = new Condition((BoxerStates)states.GetValue(random.Next(states.Length)), actions.ElementAt(random1.Next(actions.Count)));
            }
            if (k < 1000)
            {
                conditions.Add(cond);
            }
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
