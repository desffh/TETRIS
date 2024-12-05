using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class CreateGame
    {
        // 배열 초기화
        static public void reset_main_cpy()
        { //main_cpy를 초기화 
            int i, j;

            for (i = 0; i < Constants.gameHeight; i++)
            {         //게임판에 게임에 사용되지 않는 숫자를 넣음 
                for (j = 0; j < Constants.gameWidth; j++)
                {  //이는 main_org와 같은 숫자가 없게 하기 위함 
                    Program.main_cpy[i, j] = 100;
                }
            }
        }


        // 게임판 생성
        static void Reset_Game()
        {
            int i, j; // 세로, 가로

            for (i = 0; i < Constants.gameHeight; i++)
            {
                for (j = 0; j < Constants.gameWidth; j++)
                {
                    Program.main_org[i, j] = 0;
                    Program.main_cpy[i, j] = 100;
                }
            }

            // 천장 만들기 (세로 i 고정)
            for (j = 0; j < Constants.gameWidth; j++)
            {
                Program.main_org[3, j] = Constants.SPACE;
            }
            // 양쪽 벽 만들기 (가로 j 고정)
            for (i = 0; i < Constants.gameHeight - 1; i++)
            {
                Program.main_org[i, 0] = Constants.WALL;
                Program.main_org[i, Constants.gameWidth - 2] = Constants.WALL;
            }
            // 바닥 만들기 (세로 i 고정)
            for (j = 0; j < Constants.gameWidth - 1; j++)
            {
                Program.main_org[Constants.gameHeight - 1, j] = Constants.WALL;
            }

            Console.SetCursorPosition(30, 30);
            // 바닥 만들기 (세로 i 고정)
            for (j = 10; j < Constants.gameWidth - 1; j++)
            {
                Program.main_org[Constants.gameHeight - 1, j] = Constants.WALL;
            }

        }

    }
}
