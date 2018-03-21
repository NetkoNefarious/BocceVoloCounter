using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocceVoloCounter
{
    class Score
    {
        private int HitScore { get; set; }
        private Stack<bool> HitList { get; set; }

        public Score()
        {
            HitScore = 0;
            HitList = new Stack<bool>();
        }

        public void Hit()
        {
            HitScore++;
            HitList.Push(true);
        }

        public void Miss()
        {
            HitList.Push(false);
        }

        public void Remove()
        {
            if (HitList.Count > 0)
            {
                if (HitList.Peek())
                    HitScore--;

                HitList.Pop();
            }
        }

        public void Correct()
        {
            if (HitList.Count > 0)
            {
                if (HitList.Peek())
                    HitScore--;
                else
                    HitScore++;

                HitList.Push(!HitList.Pop());
            }
        }

        public string UpdateScore()
        {
            return String.Format("{0}/{1}", HitScore, HitList.Count);
        }
    }
}
