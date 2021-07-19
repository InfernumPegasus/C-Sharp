using System;

namespace Game
{
    class Program
    {
        public static void GameMenu(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("Выберите нужную опцию путем нажатия клавиши:");
                Console.WriteLine("1 - Посмотреть информацию о персонаже.");
                Console.WriteLine("2 - Отправиться на бой с монстром.");
                Console.WriteLine("3 - Использовать способность.");
                Console.WriteLine("5 - Выйти из игры.");

                switch ( Console.ReadKey().Key )
                {
                    case ConsoleKey.D1:
                        // информация о персонаже
                        Console.Clear();
                        player.EntityInfo();
                        Console.WriteLine();
                        player.Progress.GetLevelingInfo();
                        break;

                    case ConsoleKey.D2:
                        // сражение со случайным монстром
                        Console.Clear();
                        Battle.MonsterBattle(ref player);
                        break;

                    case ConsoleKey.D3:
                        // баф
                        Console.Clear();
                        player.ChooseBuff();
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        
                        break;

                    case ConsoleKey.D5:
                        // выход из игры
                        Console.Clear();
                        Console.WriteLine($"До встречи в Подземье, {Environment.UserName}!");
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
