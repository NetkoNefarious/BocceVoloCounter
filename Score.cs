using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BocceVoloCounter
{
    public static class Score
    {
        private static int HitScore { get; set; } = 0;
        private static Stack<bool> HitList { get; set; } = new Stack<bool>();

        public static void Hit()
        {
            HitScore++;
            HitList.Push(true);
        }

        public static void Miss()
        {
            HitList.Push(false);
        }

        public static void Remove()
        {
            if (HitList.Count > 0)
            {
                if (HitList.Peek())
                    HitScore--;

                HitList.Pop();
            }
        }

        public static void Correct()
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

        public static string UpdateScore()
        {
            return String.Format("{0}/{1}", HitScore, HitList.Count);
        }

        public static void Reset()
        {
            HitScore = 0;
            HitList.Clear();
        }
    }
}
