using System.Runtime.Versioning;


namespace Program
{
    // #define
    static class Constants
    {
        // 스크린 사이즈
        public const int ScreenWidth = 30;
        public const int ScreenHeight = 26;

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
                Console.SetCursorPosition(0, i);
                Console.Write("□");
                Console.SetCursorPosition(58, i);
                Console.Write("□");
            }

            Console.SetCursorPosition(0, 25);
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
            Console.SetCursorPosition(3, 3);

            for(i = 0; i < Constants.GameWidth; i++)
            {
                Console.Write("□");
            }
            for(i = 0; i < Constants.GameHeight; i++)
            {
                Console.SetCursorPosition(3, i + 3);
                Console.Write("□");
                Console.SetCursorPosition(27, i + 3);
                Console.Write("□");
            }

            Console.SetCursorPosition(3, 22);
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
            int blockNum = rand.Next(0, 7); // 블럭 종류
            int blockRotation = rand.Next(0, 4); // 블럭 회전 종류

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

        // 보드에 블럭 생성(처음 & 다시 그리기)
        static void CreateBlock(int[,] block, int posX, int posY)
        {
            for(int y = 0; y < 4; y++)
            {
                for(int x = 0; x < 4; x++)
                {
                    if (block[y, x] == 1)
                    {
                        Console.SetCursorPosition(posX + x * 2, posY + y);
                        Console.Write("■");
                    }
                }
            }
        }

        // 이전 블럭(오른쪽) 잔상 지우기
        static void ReMoveRightBlock(int[,] block, int posX, int posY)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (block[y, x] == 1)
                    {
                        Console.SetCursorPosition(posX + (x - 1) * 2, posY + y);
                        Console.Write("    ");
                        break;
                    }
                }
            }
        }

        // 이전 블럭(왼쪽) 잔상 지우기
        static void ReMoveLeftBlock(int[,] block, int posX, int posY)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (block[y, x] == 1)
                    {
                        Console.SetCursorPosition(posX + (x + 1) * 2, posY + y);
                        Console.Write("    ");
                        break;
                    }
                }
            }
        }

        // 이전 블럭(윗쪽) 잔상 지우기
        static void ReMoveUpBlock(int[,] block, int posX, int posY)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (block[y, x] == 1)
                    {
                        Console.SetCursorPosition(posX + x * 2, posY + (y - 1));
                        Console.Write("    ");
                        break;
                    }
                }
            }
        }

        // 벽에 닿는지 검사 (위치값을 토대로)
        static bool CheckWall(int[,] block, int width, int Height)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (block[x, y] == 1)
                    {

                    }
                }
            }
        }

        // 키 입력받는 함수
        static string KeyInput()
        {
            if(Console.KeyAvailable) 
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true); 

                switch(key.Key) 
                {
                    case ConsoleKey.LeftArrow: PosX -= 2;
                        return "Left";
                    case ConsoleKey.RightArrow: PosX += 2;
                        return "Right";           
                    case ConsoleKey.UpArrow:
                        return "Up";
                    case ConsoleKey.DownArrow: PosY += 1;
                        return "Down";         
                }
            }
            return "None";

        }

        // 블럭 초기 생성 위치
        static int PosX = 9;
        static int PosY = 5;

        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "TETRIS";
            Console.SetBufferSize(160, 100); // 창 내의 버퍼
                                             // (내부 컨텐츠의 크기로 문자를 나타낼 셀의 수)
            Console.SetWindowSize(60, 26);   // 창 크기

            ScreenLine();
            GameLine();

            // 반환된 selectBlock 저장
            int[,] currentBlock = RandomBlock();

            CreateBlock(currentBlock, PosX, PosY);


            while (true)
            {
                string keyAction = KeyInput(); // 키 입력을 문자열로 받음
                
                if(keyAction == "Left")
                {
                    ReMoveLeftBlock(currentBlock,PosX,PosY);
                    CreateBlock(currentBlock,PosX,PosY);
                }
                if (keyAction == "Right")
                {
                    ReMoveRightBlock(currentBlock, PosX, PosY);
                    CreateBlock(currentBlock, PosX, PosY);
                }
                if (keyAction == "Down")
                {
                    ReMoveUpBlock(currentBlock, PosX, PosY);
                    CreateBlock(currentBlock, PosX, PosY);
                }
                System.Threading.Thread.Sleep(100); // 게임 속도 조절
            }
        }
    }
}
