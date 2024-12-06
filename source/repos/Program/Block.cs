using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Block
    {
        static private int bx;
        static private int by;

        static private int b_type; //블록 종류를 저장 
        static private int b_rotation; //블록 회전값 저장 
        static private int b_type_next; //다음 블록값 저장 
        static private int b_rotation_next; //다음 블록회전값 저장 

        static private bool crush_on = true;
        static public bool new_block_on = false;

        // 4차원 배열 (테트리스 블럭)
        static public int[,,,] blocks = new int[7, 4, 4, 4]
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


        // 새 블럭 생성
        public void New_Block()
        {
            Random rand = new Random();
            int i, j;

            // 블럭 생성 위치(x, y)
            bx = (Constants.gameWidth / 2) - 3;
            by = 0;

            // 다음 블록 종류 & 회전값
            b_type = b_type_next;
            b_type_next = rand.Next(0, 7);
            b_rotation = b_rotation_next;
            b_rotation_next = rand.Next(0, 4);

            // 난수 생성
            // rand.Next(min이상, max미만)

            new_block_on = false;

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (Block.blocks[b_type, b_rotation, i, j] == 1)
                    {

                        Program.main_org[by + i, bx + j * 2] = Constants.Active_blocks;

                    }
                }
            }

            // 다음 나올 블럭
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (Block.blocks[b_type_next, b_rotation_next, i, j] == 1)
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
        static private void Move_Block(int dir)
        {
            int i, j; // 세로 가로

            switch (dir)
            {
                case 0: //왼쪽방향 
                    for (i = 0; i < 4; i++)
                    { //현재좌표의 블럭을 지움 
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1)
                            {
                                Program.main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                            }

                        }
                    }
                    bx -= 2; //좌표값 이동 

                    for (i = 0; i < 4; i++)
                    { //왼쪽으로 한칸가서 active block을 찍음 
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1) Program.main_org[by + i, bx + j * 2]
                                    = Constants.Active_blocks;
                        }
                    }
                    break;

                case 1: //오른쪽 방향 
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1)
                            {
                                Program.main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                            }
                        }
                    }
                    bx += 2; //좌표값 이동

                    for (i = 0; i < 4; i++)
                    { //오른쪽으로 한칸가서 active block을 찍음 
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1) Program.main_org[by + i, bx + j * 2]
                                    = Constants.Active_blocks;
                        }
                    }
                    break;

                case 2: //아래방향 
                    for (i = 0; i < 4; i++)
                    { //현재좌표의 블럭을 지움 
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1) Program.main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                        }
                    }
                    by += 1; //좌표값 이동

                    for (i = 0; i < 4; i++)
                    { //아래로 한칸가서 active block을 찍음 
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1) Program.main_org[by + i, bx + j * 2]
                                    = Constants.Active_blocks;
                        }
                    }
                    break;

                case 3: // Z키 (블럭 회전)
                    for (i = 0; i < 4; i++)
                    { //현재좌표의 블럭을 지움 
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1) Program.main_org[by + i, bx + j * 2] =
                                    Constants.EMPTY;
                        }
                    }

                    b_rotation = (b_rotation + 1) % 4; // 회전 1 2 3 4

                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (Block.blocks[b_type, b_rotation, i, j] == 1)
                            {

                                Program.main_org[by + i, bx + j * 2]
                                    = Constants.Active_blocks;

                            }
                        }
                    }

                    break;
            }
        }


        // 블럭 떨구기
        static public void Drop_block()
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
                        if (Program.main_org[i, j] == Constants.Active_blocks)
                        {
                            Program.main_org[i, j] = Constants.InActive_blocks;
                        }
                    }
                }
                crush_on = false; //flag를 끔 
                Check_Block(); // 블럭이 한줄이 되었는지 
                new_block_on = true; //새로운 블럭생성 flag를 켬    
                return; //함수 종료 
            }
            if (check_crush(bx, by + 1, b_rotation) == false)
            {
                Block.Move_Block(2); //밑이 비어있으면 밑으로 한칸 이동
            }

            if (check_crush(bx, by + 1, b_rotation) == true)
            {
                crush_on = true; //밑으로 이동이 안되면  crush flag를 켬
                return;
            }
        }


        // 배열 초기화
        static private void reset_main_cpy()
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


        // 블럭 체크
        static private void Check_Block()
        {
            Score totalScore = new Score();

            int i, j;

            int block_amount; // 한줄 블럭 저장


            for (i = Constants.gameHeight - 2; i > 0; i--)
            {
                block_amount = 0;
                for (j = 2; j < Constants.gameWidth - 2; j++)
                {
                    if (Program.main_org[i, j] > 0)
                    {
                        block_amount++;

                    }
                }
                if (block_amount > 8)
                {
                    // 해당 줄 삭제
                    for (j = 1; j < Constants.gameWidth - 1; j++)
                    {
                        Program.main_org[i, j] = Constants.EMPTY;

                    }
                    totalScore.TotalScore += 500;
                    // 윗줄을 아래로 이동
                    for (int k = i; k > 1; k--)
                    {
                        for (int m = 1; m < Constants.gameWidth - 1; m++)
                        {
                            // 한칸 내리기
                            if (Program.main_org[k - 1, m] != Constants.SPACE) Program.main_org[k, m] = Program.main_org[k - 1, m];
                            // 비우기
                            if (Program.main_org[k - 1, m] == Constants.SPACE) Program.main_org[k, m] = Constants.EMPTY;
                        }
                    }
                    i++;
                    // 현재 줄 재검사 (아래로 밀린 경우)
                }

            }
            Console.SetCursorPosition(30, 20);

            Console.WriteLine("Score : " + totalScore.TotalScore);
            reset_main_cpy();

        }


        // 벽이나 블록에 충돌하는지
        static private bool check_crush(int bx, int by, int rotation)
        {

            // 충돌 여부 계산 (예: 벽이나 블록과 겹치는지 확인)
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    if (Block.blocks[b_type, rotation, i, j] == 1 && Program.main_org[by + i, bx + j * 2] >= 0)
                    {
                        int newX = bx + j * 2;
                        int newY = by + i;

                        if (Program.main_org[newY, newX] != Constants.EMPTY)
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


        // 키 입력받는 함수
        static public void KeyInput()
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

                        // 회전 할 수 있는 범위
                        if (0 < bx && bx < Constants.gameWidth)
                        {
                            if (check_crush(bx, by + 1, (b_rotation + 1) % 4) == false)
                            {
                               Move_Block(3);
                            }
                        }
                        break;

                    case ConsoleKey.Spacebar:
                        while (crush_on == false)
                        {
                            Drop_block();
                        }

                        break;

                }

            }
        }


    }
}
