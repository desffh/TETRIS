using System.Runtime.Versioning;


namespace Program
{
    internal class Program
    {
        // 전체창 테두리
        static void ScreenLine()
        {
            int i = 0;

            for (i = 0; i < 50; i++)
            {
                Console.Write("□");
            }

            for(i = 0; i < 39;  i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("□");
                Console.SetCursorPosition(98, i);
                Console.Write("□");
            }

            Console.SetCursorPosition(0, 39);
            for (i = 0; i < 50; i++)
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

            for(i = 0; i < 12; i++)
            {
                Console.Write("□");
            }
            for(i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(8, i + 9);
                Console.Write("□");
                Console.SetCursorPosition(30, i + 9);
                Console.Write("□");
            }

            Console.SetCursorPosition(8, 28);
            for (i = 0; i < 12; i++)
            {
                Console.Write("□");
            }

            for(i = 0; i < 12; i++)
            {
                Console.WriteLine();
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

        // 랜덤으로 블럭 출력
        static void RandomBlocks()
        {
            // 난수 생성
            // rand.Next(min이상, max미만)
            
            Random rand = new Random();
            int blockNum = rand.Next(0, 7);
            int blockRotation = rand.Next(0, 4);

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Console.SetCursorPosition(x * 2, y);

                    if (blocks[blockNum, blockRotation, y, x] == 1)
                    {
                        Console.Write("■");
                    }

                }
            }

        }
        // 랜덤으로 가져온 블럭 저장
        int[,] SaveBlock = new int[4, 4];

        public void Save()
        {

            Random rand = new Random();
            int blockNum = rand.Next(0, 7);
            int blockRotation = rand.Next(0, 4);

            int i = 0;
            int j = 0;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    SaveBlock[i, j] = blocks[blockNum, blockRotation, y, x];
                }
            }
        }



        // 보드에 블럭 생성
        static void CreateBlocks(int[,] SaveBlock)
        {
            // 블럭이 생성 될 위치
            int x = 14;
            int y = 10;
            
            int i = 0;
            int j = 0;

            for(i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(x, y + 1);
                
                for(j = 0; j < 4; j++)
                {
                    if (SaveBlock[i, j] == 1)
                    {
                        Console.Write("  ");
                    }
                    else if (SaveBlock[i, j] == 0)
                    {
                        Console.SetCursorPosition(x+2 * (j+1), y+i);
                    }
                }
            }
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
            RandomBlocks();
            
       
        }
    }
}
