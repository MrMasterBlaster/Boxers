using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class ActionHistory
    {
        List<string> causes;
        SpriteFont textBlock;
        Vector2 startRect;

        public List<string> History { get { return causes; } }

        List<Vector2> positions;

        public ActionHistory(SpriteFont _textBlock, Rectangle _startRect)
        {
            causes = new List<string>();
            positions = new List<Vector2>();
            textBlock = _textBlock;
            startRect = new Vector2(_startRect.X, _startRect.Y + 30);
        }

        public void NewAct()
        {
            causes.Add("");
            positions.Add(new Vector2(startRect.X, startRect.Y + positions.Count * 15));
        }

        public void AddRecord(string str)
        {
            causes[causes.Count - 1] += str;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < causes.Count; i++)
            {
                spriteBatch.DrawString(textBlock, causes[i], positions[i], Color.White);
            }
        }
        
    }
}
