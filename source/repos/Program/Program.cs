using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Transactions;
using System.Xml;
using System.Xml.Serialization;


namespace Program
{

    internal class Program
    {
        static public int[,] main_org = new int[Constants.gameHeight, Constants.gameWidth * 2];
        static public int[,] main_cpy = new int[Constants.gameHeight, Constants.gameWidth * 2];


        // 게임 종료 확인
        static bool Gameover()
        {

            for (int i = 1; i < Constants.gameWidth - 2; i++)
            {
                // 첫장 윗부분
                if (main_org[3, i] > 0 && main_org[3, i] == Constants.InActive_blocks)
                {
                    return true;
                }
            }
            return false;
        }


        // 화면 셋팅
        [SupportedOSPlatform("windows")]
        static void Setting()
        {
            Console.Clear();
            Console.Title = "TETRIS";
            Console.SetBufferSize(180, 100); // 창 내의 버퍼
                                             // (내부 컨텐츠의 크기로 문자를 나타낼 셀의 수)
            Console.SetWindowSize(Constants.screenWidth, Constants.screenHeight);   // 창 크기
        }


        // 타이틀 화면
        static void TitleScreen()
        {
            CreateGame.Title(); // 타이틀 출력
            ConsoleKeyInfo consoleKey = Console.ReadKey();

            if (consoleKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                StartGame(); // 게임 시작
            }
            else
            {
                Environment.Exit(0); // 다른 키를 누르면 종료
            }
        }


        // 게임 실행
        static void StartGame()
        {
            CreateGame createGame = new CreateGame();
            createGame.Reset_Game();

            while (!Gameover()) // 게임 종료 조건 확인
            {
                // 게임 진행
                CreateGame draw = new CreateGame();
                Block newblock = new Block();

                draw.Draw();
                Block.KeyInput();
                Block.Drop_block();
                Thread.Sleep(150); // 속도 조절

                if (Block.new_block_on)
                {
                    newblock.New_Block();
                }
            }

            EndGame(); // 게임 종료 처리
        }

        // 게임 종료 화면
        static void EndGame()
        {
            Console.Clear();
            CreateGame.GameOver(); // 종료 화면 출력

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.R)
            {
                Console.Clear();
                TitleScreen(); // R키를 누르면 다시 시작
            }
            else
            {
                Environment.Exit(0); // 다른 키를 누르면 종료
            }
        }

        

        static void Main(string[] args)
        {
            Console.CursorVisible = false; // 커서 숨기기
            Setting();
            TitleScreen(); // 타이틀 화면 호출

        }
    }
    
}
    