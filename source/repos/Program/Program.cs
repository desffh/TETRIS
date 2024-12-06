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
       

        static public int bx;
        static public int by;

        static public int b_type; //블록 종류를 저장 
        static public int b_rotation; //블록 회전값 저장 
        static public int b_type_next; //다음 블록값 저장 

        static public bool crush_on = true;
        static public bool new_block_on = false;
        
        
        // 게임 종료 확인
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
        static void Setting()
        {
            Console.Clear();
            Console.Title = "TETRIS";
            Console.SetBufferSize(180, 100); // 창 내의 버퍼
                                             // (내부 컨텐츠의 크기로 문자를 나타낼 셀의 수)
            Console.SetWindowSize(Constants.screenWidth, Constants.screenHeight);   // 창 크기
        }

        
        static void Main(string[] args)
        {

            Setting();
            
            // 참조
            Block newblock = new Block();

            Block dropblock = new Block();

            CreateGame createGame = new CreateGame();
            
            CreateGame draw = new CreateGame();


            createGame.Reset_Game();
            
            while (GameOver() == false)
            {
                draw.Draw();
                
                Block.KeyInput();
            
                Block.Drop_block();
                System.Threading.Thread.Sleep(150); // 속도 조절


                // 새 블럭이 필요하면 생성
                if (new_block_on == true)
                {
                   newblock.New_Block();
                }
            }
            
            if(GameOver() == true) 
            {
                Console.Clear();
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("GameOver");
            }
        }
    }
}
    