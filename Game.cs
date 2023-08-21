using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Application
{
    class GameVars{
        public static List<string> player = new List<string>();
        public static int PPos = 0;
        public static int RevoMaxCase = 6;
        public static int RevoPos = 0;
        public static int RevoCurPos = 0;
    }
    class Game{
        InputManager inputManager = new InputManager();

        public void Boot(){
            // Setup the Game First
            WriteLine($"Running Game...");
            GameVars.player.Add("Prince");
            GameVars.player.Add("Glenn");
            GameVars.player.Add("Earl");
            GameVars.player.Add("Jerome");

            GameVars.RevoMaxCase = GameVars.player.Count;
            Start();
        }
        public void Start(){
            CockGun();
            Next();
        }
        public void Next(){
            WriteLine("----------------");
            if(GameVars.player.Count <= 1){
                WriteLine($"{GameVars.player[0]} you won!\n");
                return;
            }
            WriteLine($"<Dev>Players {GameVars.PPos} | {GameVars.player.Count}");
            WriteLine($"{GameVars.player.Count} players alive");
            if(GameVars.PPos >= GameVars.player.Count){
                GameVars.PPos = 0;
            }
            WriteLine("----------------");
            WriteLine($"{GameVars.player[GameVars.PPos]} your turn...");
            WriteLine($"Press any key to continue");
            Check(inputManager.Action());
        }
        
        void RenderGame(){

        }

        void Check(int index){
            switch (index){
                case 1:
                    Boot();
                break;
                case 2:
                    FireGun(GameVars.PPos);
                break;
            }
        }

        // Gun Settings
        void Skip(){

        }
        void FireGun(int a){
            if(GameVars.RevoCurPos > GameVars.RevoMaxCase){GameVars.RevoCurPos = 0;}
            if(GameVars.RevoPos == GameVars.RevoCurPos){
                WriteLine($"{GameVars.player[a]} Died! met in Cur{GameVars.RevoCurPos} | Pos{GameVars.RevoPos} | Max{GameVars.RevoMaxCase}\n");
                GameVars.player.RemoveAt(a);
                GameVars.PPos ++;
                CockGun();
                Next();
            }else{
                WriteLine($"<Dev>Bullet Cur{GameVars.RevoCurPos} | Pos{GameVars.RevoPos} | Max{GameVars.RevoMaxCase}\n");
                GameVars.RevoCurPos ++;
                GameVars.PPos ++;
                Next();
            }
        }
        void CockGun(){
            int prevPos = GameVars.RevoPos;
            Random rand = new Random();
            GameVars.RevoPos = rand.Next(0,GameVars.RevoMaxCase);
            if(prevPos == GameVars.RevoPos){
                Console.WriteLine($"<Dev>same random number || {GameVars.RevoPos}");
                CockGun();
            }
        }
    }
}