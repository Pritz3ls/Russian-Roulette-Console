using System;
using System.Collections.Generic;
using static System.Console;
namespace Application
{
    class InputManager
    {
        public int Action(){
            ConsoleKey keypressed;
            // Input Index: Skip - 1, Fire - 2
            int index = 0;
            do{    
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keypressed = keyInfo.Key;
                if(keypressed == ConsoleKey.Enter){index = 1;
                }else if(keypressed == ConsoleKey.Spacebar){index = 2;}
                return index;
            } while (keypressed != ConsoleKey.Backspace);
        }
        public string InputName(){
            ConsoleKey keypressed;
            string name = "";
            do{
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keypressed = keyInfo.Key;
                name = ReadLine();
                return name;
            } while (keypressed != ConsoleKey.Spacebar);
        }
    }
}