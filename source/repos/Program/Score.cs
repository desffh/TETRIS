using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Score
    {
        // 전체 점수
        static private int score {  get; set; }

        // 전체 점수
        public int TotalScore
        {
            get { return score; }

            set { score = value; }
        }


    }
}
