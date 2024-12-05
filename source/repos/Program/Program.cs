using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Xml;
using System.Xml.Serialization;


namespace Program
{
    
    internal class Program
    {
        static public int[,] main_org = new int[Constants.gameHeight, Constants.gameWidth * 2];
        static public int[,] main_cpy = new int[Constants.gameHeight, Constants.gameWidth * 2];

  

        static void Color()
        {
            Random random = new Random();
            random.Next(0, 3);

            return;
        }


        static public int bx;
        static public int by;

        static public int b_type; //블록 종류를 저장 
        static public int b_rotation; //블록 회전값 저장 
        static public int b_type_next; //다음 블록값 저장 

        static public bool crush_on = true;
        static public bool new_block_on = false;
        
        static public bool check_crush(int bx, int by, int rotation)
        {
            
            // 충돌 여부 계산 (예: 벽이나 블록과 겹치는지 확인)
            for (int i = 0; i < 4; i++)
            {
                
                for (int j = 0; j < 4; j++)
                {
                    if (Block.blocks[b_type, rotation, i, j] == 1 && main_org[by + i, bx + j * 2] >= 0)
                    {
                        int newX = bx + j * 2;
                        int newY = by + i;

                        if (main_org[newY, newX] != Constants.EMPTY)
                        {
                            return true; // 충돌 발생 (새로운 위치가 빈곳이 아니면 충돌)
                        }
                        // 좌표가 범위 안에 있는지 확인
                        if (newX < 0 || newX >= Constants.gameWidth || newY < 0 || newY >= Constants.gameHeight)
                        {
                            return false; // 범위를 벗어나면 충돌로 처리
                        }
                    }
                    
                }
            }
            return false; // 충돌 없음
        }


        static public void reset_main_cpy()
        { //main_cpy를 초기화 
            int i, j;

            for (i = 0; i < Constants.gameHeight; i++)
            {         //게임판에 게임에 사용되지 않는 숫자를 넣음 
                for (j = 0; j < Constants.gameWidth; j++)
                {  //이는 main_org와 같은 숫자가 없게 하기 위함 
                    main_cpy[i,j] = 100;
                }
            }
        }

        // 게임판 만들기
        static void Reset_Game()
        {
            int i, j; // 세로, 가로

            for (i = 0; i < Constants.gameHeight; i++)
            {
                for (j = 0; j < Constants.gameWidth; j++)
                {
                    main_org[i, j] = 0;
                    main_cpy[i, j] = 100;
                }
            }

            // 천장 만들기 (세로 i 고정)
            for (j = 0; j < Constants.gameWidth; j++)
            {
                main_org[3, j] = Constants.SPACE;
            }
            // 양쪽 벽 만들기 (가로 j 고정)
            for (i = 0; i < Constants.gameHeight - 1; i++)
            {
                main_org[i, 0] = Constants.WALL;
                main_org[i, Constants.gameWidth - 2] = Constants.WALL;
            }
            // 바닥 만들기 (세로 i 고정)
            for (j = 0; j < Constants.gameWidth - 1; j++)
            {
                main_org[Constants.gameHeight - 1, j] = Constants.WALL;
            }

            Console.SetCursorPosition(30, 30);
            // 바닥 만들기 (세로 i 고정)
            for (j = 10; j < Constants.gameWidth - 1; j++)
            {
                main_org[Constants.gameHeight - 1, j] = Constants.WALL;
            }

        }

        // 게임판 그리기
        static void Draw_Game()
        {
            int i, j;

            for (j = 1; j < Constants.gameWidth; j++)
            {
                if (main_org[3, j] == Constants.EMPTY)
                {
                    main_org[3, j] = Constants.SPACE;
                }
            }

            for (i = 0; i < Constants.gameHeight; i++)
            {
                for (j = 0; j < Constants.gameWidth; j++)
                {
                    if (main_cpy[i, j] != main_org[i, j])
                    {
                        Console.SetCursorPosition(Constants.gamePosX + j , Constants.gamePosY + i);
                        switch (main_org[i, j])
                        {
                            case Constants.EMPTY: //빈칸모양 
                                Console.Write("  ");
                                break;
                            case Constants.SPACE: //천장모양 
                                Console.Write("- ");
                                break;
                            case Constants.WALL: //벽모양 
                                Console.Write("▣");
                                break;
                            case Constants.InActive_blocks: //굳은 블럭 모양  
                                Console.Write("□");
                                break;
                            case Constants.Active_blocks: //움직이고있는 블럭 모양
                                Color();
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
                    main_cpy[i, j] = main_org[i, j ];
                }
            }
        }
        
        // 키 입력받는 함수
        static void KeyInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        // 충돌이 없으면 이동
                        if (check_crush(bx - 2, by, b_rotation) == false)
                        {
                            Block.Move_Block(0);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (check_crush(bx + 2, by, b_rotation) == false)
                        {
                            Block.Move_Block(1);
                        }//PosX += 2;
                        break;

                    case ConsoleKey.DownArrow:
                        if (check_crush(bx, by + 1, b_rotation) == false)
                        {
                            Block.Move_Block(2);
                        }//PosY += 1;
                        break;

                    // Z키는 블럭을 회전
                    case ConsoleKey.Z:

                        // 회전 할 수 있는 범위
                        if (0 < bx && bx < Constants.gameWidth)
                        {
                            if(check_crush(bx, by + 1, (b_rotation + 1) % 4) == false)
                            {
                                Block.Move_Block(3);
                            }
                        }
                        break;

                    case ConsoleKey.Spacebar:
                        while(crush_on == false)
                        {
                            Block.Drop_block();
                        }

                        break;

                }
            
            }
        }

        static bool GameOver()
        {

            for(int i = 1;i < Constants.gameWidth - 2;i++)
            {
                // 첫장 윗부분
                if (main_org[3,i] > 0 && main_org[3,i] == Constants.InActive_blocks)
                {
                    return true;
                }
            }
            return false;
        }


        [SupportedOSPlatform("windows")]
        
        static void Main(string[] args)
        {
            //Color();

            Console.Clear();
            Console.Title = "TETRIS";
            Console.SetBufferSize(120, 52); // 창 내의 버퍼
                                             // (내부 컨텐츠의 크기로 문자를 나타낼 셀의 수)
            Console.SetWindowSize(Constants.screenWidth, Constants.screenHeight);   // 창 크기
            
            
            Reset_Game();
            Block.New_Block();
            
            while (GameOver() == false)
            {
                Draw_Game();
                
                KeyInput();
            
                Block.Drop_block();
            
                // 새 블럭이 필요하면 생성
                if(new_block_on == true)
                {
                    Block.New_Block();
                }
            
                System.Threading.Thread.Sleep(150); // 속도 조절
            }
            
            if(GameOver() == true) 
            {
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("GameOVer");
            }
        }
    }
}
    