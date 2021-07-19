using System;

namespace Game
{
    /// <summary>
    /// Реализация монстров
    /// </summary>
    class Monster : GameEntity
    {
        public int ExperienceByKill { get; protected set; }

        private static readonly Random random = new();

        // массив, содержащий всех монстров
        private static readonly Monster[] monsters =
            {
                new()
                {
                    Damage = 4,
                    Defence = 3,
                    HealthPoint = 30,
                    MaxHealthPoint = 30,
                    Name = "Гоблин",
                    ExperienceByKill = 75
                },
                new()
                {
                    Damage = 5,
                    Defence = 4,
                    HealthPoint = 35,
                    MaxHealthPoint = 35,
                    Name = "ХобГоблин",
                    ExperienceByKill = 100
                },
                new()
                {
                    Damage = 6,
                    Defence = 5,
                    HealthPoint = 50,
                    MaxHealthPoint = 50,
                    Name = "Орк",
                    ExperienceByKill = 125
                }
            };

        // генератор монстра из пула monsters
        public static Monster GetRandomMonster()
        {
            return monsters[random.Next(0, monsters.Length)];
        }
    }
}
