using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class CreateGame
    { 
        static public void Title()
        {
            int i, j;
            
            Console.SetCursorPosition(10, 5);
            for(i = 0; i < 20; i++) 
            {
                Console.Write("◈");
            }
            
            for(j = 5;  j < 10; j++)
            {
                Console.SetCursorPosition(10, j);
                Console.Write("◈");

                Console.SetCursorPosition(50, j);
                Console.Write("◈");
            }

            Console.SetCursorPosition(10, 10);
            for (i = 0; i < 21; i++)
            {
                Console.Write("◈");
            }

            Console.SetCursorPosition(20, 12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press to Enter TETRIS");
            Console.ResetColor();
        }

        static public void GameOver()
        {
            int i, j;

            Console.SetCursorPosition(10, 5);
            for (i = 0; i < 20; i++)
            {
                Console.Write("◈");
            }

            for (j = 5; j < 10; j++)
            {
                Console.SetCursorPosition(10, j);
                Console.Write("◈");

                Console.SetCursorPosition(50, j);
                Console.Write("◈");
            }

            Console.SetCursorPosition(10, 10);
            for (i = 0; i < 21; i++)
            {
                Console.Write("◈");
            }

            Console.SetCursorPosition(25, 12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game Over");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(23, 14);
            Console.WriteLine("'R' Enter to Retry");
            Console.ResetColor();
        }


        // 게임판 생성
        public void Reset_Game()
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

            

        }

        // 게임판 그리기
        private void Draw_Game()
        {
            int i, j;

            for (j = 1; j < Constants.gameWidth; j++)
            {
                if (Program.main_org[3, j] == Constants.EMPTY)
                {
                    Program.main_org[3, j] = Constants.SPACE;
                }
            }

            for (i = 0; i < Constants.gameHeight; i++)
            {
                for (j = 0; j < Constants.gameWidth; j++)
                {
                    if (Program.main_cpy[i, j] != Program.main_org[i, j])
                    {
                        Console.SetCursorPosition(Constants.gamePosX + j, Constants.gamePosY + i);
                        switch (Program.main_org[i, j])
                        {
                            case Constants.EMPTY: //빈칸2칸 
                                Console.Write("  ");
                                break;
                            case Constants.SPACE: //천장모양 
                                Console.Write("- ");
                                break;
                            case Constants.WALL: //벽모양 
                                Console.Write("▣");
                                break;
                            case Constants.InActive_blocks: //굳은 블럭 모양  
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("■");
                                Console.ResetColor();
                                break;
                            case Constants.Active_blocks: //움직이고있는 블럭 모양

                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("■");
                                Console.ResetColor();
                                break;
                        }
                    }
                }
            }
            // 복사해서 넣기
            for (i = 0; i < Constants.gameHeight; i++)
            {
                for (j = 0; j < Constants.gameWidth; j++)
                {
                    Program.main_cpy[i, j] = Program.main_org[i, j];
                }
            }
        }


        // 다음 블록 상자
        private void Draw_Map()
        {
            Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 1, 2);
            Console.WriteLine("▣▣▣▣▣▣▣▣");
            
            Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 1, 3);
            for (int i = 3; i < 9; i++)
            {
                Console.WriteLine("▣");
                Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 1, i);
            }

            Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 1, 3);
            for (int i = 3; i < 9; i++)
            {
                Console.WriteLine("▣");
                Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 15, i);
            }

            Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 1, 3 + 5);
            Console.WriteLine("▣▣▣▣▣▣▣▣");



        }
    
        
        public void Draw()
        {
            Draw_Game();
            Draw_Map();
        }

    }
}
