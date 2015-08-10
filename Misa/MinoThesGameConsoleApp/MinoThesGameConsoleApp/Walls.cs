using System;

namespace MinoThesGameConsoleApp
{
    [Flags]
    enum Walls
    {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
        None = 0
    }
}
