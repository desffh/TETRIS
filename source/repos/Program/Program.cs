using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.Versioning;
using System.Xml.Serialization;


namespace Program
{
    
    internal class Program
    {
        static int[,,,] blocks = new int[7, 4, 4, 4]
                {
                    // ㅡ ㅣ 블럭
                    {
                        {
                            {0, 0, 0, 0},
                            {1, 1, 1, 1},
                            {0, 0, 0, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 1, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {1, 1, 1, 1},
                            {0, 0, 0, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 1, 0}
                        }
                    },

                    // ㄴ 블럭
                    {
                        {
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 1, 1},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {1, 1, 1, 0},
                            {1, 0, 0, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 1, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 0},
                            {1, 1, 1, 0},
                            {0, 0, 0, 0},
                            {0, 0, 0, 0}
                        }
                    },

                    // 거꾸로 ㄴ 블럭
                    {
                        {
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 1, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {1, 0, 0, 0},
                            {1, 1, 1, 0},
                            {0, 0, 0, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 1},
                            {0, 0, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 1},
                            {0, 0, 0, 1},
                            {0, 0, 0, 0}
                        }
                    },

                    // ㅗ 블럭
                    {
                        {
                            {0, 1, 0, 0},
                            {1, 1, 1, 0},
                            {0, 0, 0, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 0},
                            {0, 0, 1, 1},
                            {0, 0, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 1},
                            {0, 0, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 0},
                            {0, 1, 1, 0},
                            {0, 0, 1, 0},
                            {0, 0, 0, 0}
                        }
                    },

                    // ㄹ 블럭
                    {
                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 0},
                            {0, 0, 1, 1},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 1},
                            {0, 0, 1, 1},
                            {0, 0, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 0},
                            {0, 0, 1, 1},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 1},
                            {0, 0, 1, 1},
                            {0, 0, 1, 0},
                            {0, 0, 0, 0}
                        }
                    },

                    // 거꾸로 ㄹ 블럭
                    {
                        {
                            {0, 0, 0, 0},
                            {0, 0, 1, 1},
                            {0, 1, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 0},
                            {0, 0, 1, 1},
                            {0, 0, 0, 1},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {0, 0, 1, 1},
                            {0, 1, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 1, 0},
                            {0, 0, 1, 1},
                            {0, 0, 0, 1},
                            {0, 0, 0, 0}
                        }
                    },

                    // ㅁ 블럭
                    {
                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 0},
                            {0, 1, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 0},
                            {0, 1, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 0},
                            {0, 1, 1, 0},
                            {0, 0, 0, 0}
                        },

                        {
                            {0, 0, 0, 0},
                            {0, 1, 1, 0},
                            {0, 1, 1, 0},
                            {0, 0, 0, 0}
                        }

                    }
                };

        static int[,] main_org = new int[Constants.gameHeight, Constants.gameWidth * 2];
        static int[,] main_cpy = new int[Constants.gameHeight, Constants.gameWidth * 2];

        static int bx;
        static int by;

        static int b_type; //블록 종류를 저장 
        static int b_rotation; //블록 회전값 저장 
        static int b_type_next; //다음 블록값 저장 

        static bool check_crush(int bx, int by, int rotation)
        {
            // 충돌 여부 계산 (예: 벽이나 블록과 겹치는지 확인)
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (blocks[b_type, rotation, i, j] == 1 && main_org[by + i, bx + j * 2] > 0)
                    {
                        int newX = bx + j * 2;
                        int newY = by + i;

                        if (main_org[newY, newX] != Constants.EMPTY)
                        {
                            return true; // 충돌 발생 (새로운 위치가 빈곳이 아니면 충돌)
                        }
                    }
                }
            }
            return false; // 충돌 없음
        }

        static bool crush_on = true;
        static bool new_block_on = false;


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

            //// 천장 만들기 (세로 i 고정)
            //for (j = 0; j < Constants.gameWidth; j++)
            //{
            //    main_org[3, j] = Constants.SPACE;
            //}
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
        }


        // 게임판 그리기
        static void Draw_Game()
        {
            int i, j;

            //for (j = 1; j < Constants.gameWidth; j++)
            //{
            //    if (main_org[3, j] == Constants.EMPTY)
            //    {
            //        main_org[3, j] = Constants.SPACE;
            //    }
            //}

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
                                Console.Write(". ");
                                break;
                            case Constants.WALL: //벽모양 
                                Console.Write("▩");
                                break;
                            case Constants.InActive_blocks: //굳은 블럭 모양  
                                Console.Write("□");
                                break;
                            case Constants.Active_blocks: //움직이고있는 블럭 모양  
                                Console.Write("■");
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

        // 새 블럭 생성
        static void New_Block()
        {
            Random rand = new Random();
            int i, j;

            // 블럭 생성 위치(x, y)
            bx = (Constants.gameWidth / 2) - 1;
            by = 0;

            b_type = b_type_next;
            b_type_next = rand.Next(0, 7);
            b_rotation = 0;
            // 난수 생성
            // rand.Next(min이상, max미만)

            new_block_on = false;

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (blocks[b_type, b_rotation, i, j] == 1)
                    {
                        main_org[by + i, bx + j * 2] = Constants.Active_blocks;
                    }
                }
            }
            // 다음 나올 블럭
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (blocks[b_type_next, 0, i, j] == 1)
                    {
                        Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 4 + j * 2, i + 4);
                        Console.Write("■");
                    }
                    else
                    {
                        Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 4 + j * 2, i + 4);
                        Console.Write("  ");
                    }
                }
            }
            

        }

        // 블럭 이동
        static void Move_Block(int dir)
        {
            int i, j; // 세로 가로

            switch (dir)
            {
                case 0: //왼쪽방향 
                    for (i = 0; i < 4; i++)
                    { //현재좌표의 블럭을 지움 
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type, b_rotation, i, j] == 1)
                            {
                                main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                            }

                        }
                    }
                    bx -= 2; //좌표값 이동 

                    for (i = 0; i < 4; i++)
                    { //왼쪽으로 한칸가서 active block을 찍음 
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type,b_rotation,i,j] == 1) main_org[by + i,bx + j * 2]
                                    = Constants.Active_blocks;
                        }
                    }
                    break;

                case 1: //오른쪽 방향 
                    for (i = 0; i < 4; i++)
                    { 
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type, b_rotation, i, j] == 1)
                            {
                                main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                            }
                        }
                    }
                    bx += 2; //좌표값 이동

                    for (i = 0; i < 4; i++)
                    { //오른쪽으로 한칸가서 active block을 찍음 
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type, b_rotation, i, j] == 1) main_org[by + i, bx + j * 2]
                                    = Constants.Active_blocks;
                        }
                    }
                    break;

                case 2: //아래방향 
                    for (i = 0; i < 4; i++)
                    { //현재좌표의 블럭을 지움 
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type, b_rotation, i, j] == 1) main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                        }
                    }
                    by += 1; //좌표값 이동

                    for (i = 0; i < 4; i++)
                    { //아래로 한칸가서 active block을 찍음 
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type, b_rotation, i, j] == 1) main_org[by + i, bx + j * 2]
                                    = Constants.Active_blocks;
                        }
                    }
                    break;

                case 3: // Z키 (블럭 회전)
                    for (i = 0; i < 4; i++)
                    { //현재좌표의 블럭을 지움 
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type, b_rotation, i, j] == 1) main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                        }
                    }

                    b_rotation = (b_rotation + 1) % 4; // 회전 1 2 3 4

                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (blocks[b_type, b_rotation, i, j] == 1) main_org[by + i, bx + j * 2]
                                    = Constants.Active_blocks;
                        }
                    }

                    break;
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
                            Move_Block(0);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (check_crush(bx + 2, by, b_rotation) == false)
                        {
                            Move_Block(1);
                        }//PosX += 2;
                        break;

                    case ConsoleKey.DownArrow:
                        if (check_crush(bx, by + 1, b_rotation) == false)
                        {
                            Move_Block(2);
                        }//PosY += 1;
                        break;

                    // Z키는 블럭을 회전
                    case ConsoleKey.Z:

                        if (check_crush(bx, by + 1, b_rotation) == false)
                        {
                            Move_Block(3);
                        }
                        else
                        {
                            return;
                        }
                        break;

                }
            
            }
        }

        static void drop_block()
        {
            int i, j;

            // 아무것도 없을 때
            if (crush_on && check_crush(bx, by + 1, b_rotation) == false)
            {
                crush_on = false; //밑이 비어있으면 crush flag 끔 
            }
            // 블럭이 있을 때
            if (crush_on && check_crush(bx, by + 1, b_rotation) == true)
            {   //밑이 비어있지않고 crush flag가 켜저있으면 
                for (i = 0; i < Constants.gameHeight; i++)
                { //현재 조작중인 블럭을 굳힘 
                    for (j = 0; j < Constants.gameWidth; j++)
                    {
                        if (main_org[i, j] == Constants.Active_blocks)
                        {
                            main_org[i, j] = Constants.InActive_blocks;
                        }
                    }
                }
                crush_on = false; //flag를 끔 
                //check_line(); //라인체크를 함 
                new_block_on = true; //새로운 블럭생성 flag를 켬    
                return; //함수 종료 
            }
            if (check_crush(bx, by + 1, b_rotation) == false) Move_Block(2); //밑이 비어있으면 밑으로 한칸 이동 

            if (check_crush(bx, by + 1, b_rotation) == true)
            {
                crush_on = true; //밑으로 이동이 안되면  crush flag를 켬
                return;
            }
        }


        [SupportedOSPlatform("windows")]
        
        static void Main(string[] args)
        {

            Console.Clear();
            Console.Title = "TETRIS";
            Console.SetBufferSize(160, 100); // 창 내의 버퍼
                                             // (내부 컨텐츠의 크기로 문자를 나타낼 셀의 수)
            Console.SetWindowSize(60, 26);   // 창 크기
        

            
            Reset_Game();
            New_Block();

            // System.Threading.Thread.Sleep(500); // 속도 조절
        
            while (true)
            {
                Draw_Game();
                // 키 입력 처리
                KeyInput();

                drop_block();
                if(new_block_on == true)
                {
                    New_Block();
                }
                // 게임판 그리기

                System.Threading.Thread.Sleep(300); // 속도 조절

            }
        }
    }
}
    