using System;

namespace Game
{
    class Program
    {
        private static ConsoleKey key = new();
        public static void GameMenu(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("Выберите нужную опцию путем нажатия клавиши:");
                Console.WriteLine("1 - Посмотреть информацию о персонаже.");
                Console.WriteLine("2 - Отправиться на бой с монстром.");
                Console.WriteLine("5 - Выйти из игры.");

                key = Console.ReadKey().Key;

                switch (key)
                {
                    /*
                    case ConsoleKey.Spacebar:
                        break;

                    case ConsoleKey.LeftArrow:
                        break;
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break; 
                     */

                    case ConsoleKey.D1:
                        Console.Clear();
                        player.GetPlayerInfo();
                        player.Progress.GetLevelingInfo();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Battle.MonsterBattle(ref player);
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Abilities.HealPercent(player);
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine($"Пока, {Environment.UserName}");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
            
        }
        static void Main(string[] args)
        {
            Player player = new();

            GameMenu(ref player);


        }
    }
}
