using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class Boxer
    {
        public int hp;
        public int points;

        Rectangle icon;
        Rectangle hpPos;
        public Texture2D hpTex;

        public BoxerState bs = new BoxerState();
        AI ai;

        Boxer enemy;
        public int HitHimAt {set { hp = hp - (value - bs.blockSize); } }
        public Boxer SetEnemy { set { enemy = value; ai.SelectEnemy(value); } }

        public Boxer(Rectangle _icon)
        {
            icon = _icon;
            hp = 100;
            points = 0;
            ai = new AI(this);
            hpPos = new Rectangle(icon.X, icon.Y + 300, 100, 30);
            bs.BS = BoxerStates.Block;
        }


        public void Hit()
        {
            bs.BS = BoxerStates.Hit;
            enemy.HitHimAt = 10;

            switch (enemy.bs.BS)
            {
                case BoxerStates.Hit:
                    ai.controlValue.weigth += 1;
                    points += 1;
                    break;
                case BoxerStates.Block:
                    ai.controlValue.weigth -= 1;
                    points += 0;
                    break;
                case BoxerStates.Wait:
                    ai.controlValue.weigth += 2;
                    points += 1;
                    break;
                default:
                    break;
            }
        }

        public void Block()
        {
            bs.BS = BoxerStates.Block;

            switch (enemy.bs.BS)
            {
                case BoxerStates.Hit:
                    ai.controlValue.weigth += 1;
                    points += 0;
                    break;
                case BoxerStates.Block:
                    ai.controlValue.weigth += 0;
                    points += 0;
                    break;
                case BoxerStates.Wait:
                    ai.controlValue.weigth -= 1;
                    points += 0;
                    break;
                default:
                    break;
            }
        }

        public void Wait()
        {
            bs.BS = BoxerStates.Wait;
            hp += 5;

            switch (enemy.bs.BS)
            {
                case BoxerStates.Hit:
                    ai.controlValue.weigth -= 1;
                    points += 0;
                    break;
                case BoxerStates.Block:
                    ai.controlValue.weigth += 1;
                    points += 0;
                    break;
                case BoxerStates.Wait:
                    ai.controlValue.weigth += 0;
                    points += 0;
                    break;
                default:
                    break;
            }
        }
        

        public void Update()
        {
            if (bs.GetIdleTime() <= 0)
            {
                ai.DoAction();
            }
            bs.Update();
            hpPos.Width = hp;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bs.texture, icon, Color.White);
            spriteBatch.Draw(hpTex, hpPos, Color.White);

        }
    }
}
