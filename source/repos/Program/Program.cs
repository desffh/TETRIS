using System.Runtime.Versioning;


namespace Program
{
    // #define
    static class Constants
    {
        // 스크린 사이즈
        public const int ScreenWidth = 50;
        public const int ScreenHeight = 39;

        // 게임화면 사이즈
        public const int GameWidth = 12; // 실제 영역은 테두리 제외하고 10칸 (20)
        public const int GameHeight = 20;

    }


    internal class Program
    {
        // 전체창 테두리
        static void ScreenLine()
        {
            int i = 0;

            for (i = 0; i < Constants.ScreenWidth; i++)
            {
                Console.Write("□");
            }

            for(i = 0; i < Constants.ScreenHeight;  i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("□");
                Console.SetCursorPosition(98, i);
                Console.Write("□");
            }

            Console.SetCursorPosition(0, 39);
            for (i = 0; i < Constants.ScreenWidth; i++)
            {
                Console.Write("□");
            }

            return;
        }

        // 게임 테두리
        static void GameLine()
        {
            int i = 0;
            Console.SetCursorPosition(8, 8);

            for(i = 0; i < Constants.GameWidth; i++)
            {
                Console.Write("□");
            }
            for(i = 0; i < Constants.GameHeight; i++)
            {
                Console.SetCursorPosition(8, i + 9);
                Console.Write("□");
                Console.SetCursorPosition(30, i + 9);
                Console.Write("□");
            }

            Console.SetCursorPosition(8, 28);
            for (i = 0; i < Constants.GameWidth; i++)
            {
                Console.Write("□");
            }          
        }


        // 4차원 배열 : 블럭 요소
        static int[,,,] blocks = new int[7, 4, 4, 4]
            {
                // ㅡ ㅣ 블럭
                {
                    {
                        {0, 0, 0, 0},
                        {0, 0, 0, 0},
                        {1, 1, 1, 1},
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
                        {0, 0, 0, 0},
                        {1, 1, 1, 1},
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
                        {0, 1, 1, 1},
                        {0, 1, 0, 0},
                        {0, 0, 0, 0}
                    },

                    {
                        {0, 1, 1, 0},
                        {0, 0, 1, 0},
                        {0, 0, 1, 0},
                        {0, 0, 0, 0}
                    },

                    {
                        {0, 0, 0, 1},
                        {0, 1, 1, 1},
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
                        {0, 1, 0, 0},
                        {0, 1, 1, 1},
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
                        {0, 0, 1, 0},
                        {0, 1, 1, 1},
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

        // 랜덤으로 블럭 생성 & 저장
        static int[,] RandomBlock()
        {
            // 난수 생성
            // rand.Next(min이상, max미만)
            
            Random rand = new Random();
            int blockNum = rand.Next(0, 7);
            int blockRotation = rand.Next(0, 4);

            // 랜덤으로 가져온 블럭 저장
            int[,] SelectBlock = new int[4, 4];

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    SelectBlock[y, x] = blocks[blockNum, blockRotation, y, x];
                }
            }
            return SelectBlock;
        }

        // 보드에 블럭 생성
        static void CreateBlock(int[,] block, int posX, int posY)
        {
            // Console.SetCursorPosition(14, 10); 
            for(int y = 0; y < 4; y++)
            {
                for(int x = 0;x < 4; x++)
                {
                    if (block[y, x] == 1)
                    {
                        Console.SetCursorPosition(posX + x * 2, posY + y);
                        Console.Write("■");
                    }
                }
            }
        }

        // 이전 블럭 잔상 지우기
        static void ReMoveBlock(int[,] block, int posX, int posY)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (block[y, x] == 1)
                    {
                        Console.SetCursorPosition(posX + x * 2, posY + y);
                        Console.Write("  ");
                    }
                }
            }
        }

        // 블럭 다시 그리기
        static void ReCreateBlock(int[,] block, int posX, int posY)
        {
            // Console.SetCursorPosition(14, 10); 
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (block[y, x] == 1)
                    {
                        Console.SetCursorPosition(posX + x * 2, posY + y);
                        Console.Write("■");
                    }
                }
            }
        }

        // 블럭 초기 생성 위치
        static int PosX = 14;
        static int PosY = 9;

        // 키 입력받는 함수
        static bool KeyInput()
        {
            if(Console.KeyAvailable) 
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);
            
                switch(key.Key) 
                {
                    case ConsoleKey.LeftArrow: PosX -= 2;
                        break;
                    case ConsoleKey.RightArrow: PosX += 2;
                        break;
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow: PosY += 1;
                        break;
                }
                return true;
            }
            return false;


        }


        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "TETRIS";
            Console.SetBufferSize(160, 50); // 창 내의 버퍼
                                            // (내부 컨텐츠의 크기로 문자를 나타낼 셀의 수)

            Console.SetWindowSize(100, 50);   // 창 크기

            ScreenLine();
            GameLine();

            // 반환된 selectBlock 저장
            int[,] currentBlock = RandomBlock();

            CreateBlock(currentBlock, PosX, PosY);

            while (true)
            {
                bool isKeyPressed = KeyInput();

                if(isKeyPressed == true)
                {
                    ReMoveBlock(currentBlock, PosX, PosY); 

                    ReCreateBlock(currentBlock, PosX, PosY);
                }
                System.Threading.Thread.Sleep(100); // 게임 속도 조절
            }

           // for (int i = 0; i < 30; i++)
           // {
           //     Console.WriteLine();
           // }
        }
    }
}
