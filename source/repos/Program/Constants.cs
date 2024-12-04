using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    // 정의
    internal class Constants
    {
            // 스크린 사이즈
            public const int screenWidth = 30;
            public const int screenHeight = 26;

            // 게임화면 사이즈
            public const int gameHeight = 24;
            public const int gameWidth = 11 * 2; // 실제 게임 영역 10

            // 게임판 위치
            public const int gamePosX = 2 * 2;
            public const int gamePosY = 1;

            // 상태
            public const int Active_blocks = -2;
            public const int SPACE = -1;
            public const int EMPTY = 0;
            public const int WALL = 1;
            public const int InActive_blocks = 2;

    }
}
