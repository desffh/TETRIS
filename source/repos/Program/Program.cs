using System.Data;
using System.Runtime.Versioning;

namespace Program
{
    // #define
    static class Constants
    {
        // 스크린 사이즈
        public const int screenWidth = 30;
        public const int screenHeight = 26;

        // 게임화면 사이즈
        public const int gameHeight = 24;
        public const int gameWidth = 12 * 2; // 실제 게임 영역 10

        // 게임판 위치
        public const int gamePosX = 2 * 2;
        public const int gamePosY = 1;

        // 상태
        public const int Active_blocks = -2;
        public const int SPACE = -1;
        public const int EMPTY = 0;
        public const int WALL = 1;
        public const int InActive_blocks = 2;

        public const string LEFT = "LeftArrow";
    }

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

        static int[,] main_org = new int[Constants.gameHeight, Constants.gameWidth];
        static int[,] main_cpy = new int[Constants.gameHeight, Constants.gameWidth];

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
                    if (blocks[b_type, rotation, i, j] == 1)
                    {
                        int newX = bx + j;
                        int newY = by + i;

                        if (main_org[newY, newX] != Constants.EMPTY)
                        {
                            return false; // 충돌 발생
                        }
                    }
                }
            }
            return true; // 충돌 없음
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
                        Console.SetCursorPosition(Constants.gamePosX + j, Constants.gamePosY + i);
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
                    main_cpy[i, j] = main_org[i, j];
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
                        Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 4 + j * 2, i + 5);
                        Console.Write("■");
                    }
                    else
                    {
                        Console.SetCursorPosition(Constants.gamePosX + Constants.gameWidth + 3 + j, i + 6);
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
                            if (blocks[b_type, b_rotation, i, j] == 1) main_org[by + i, bx + j] =
                                    Constants.EMPTY;
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
                        if (check_crush(bx - 1, by, b_rotation))
                        {
                            Move_Block(0);
                        }
                        break;
                    case ConsoleKey.RightArrow: //PosX += 2;
                        break;

                    case ConsoleKey.UpArrow:
                        break;

                    case ConsoleKey.DownArrow: //PosY += 1;
                        break;
                }
            
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
            Draw_Game();
            System.Threading.Thread.Sleep(500); // 속도 조절
        
        }
    }
}
    