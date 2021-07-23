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

        public static Monster GetMonster()
        {
            var monster = monsters[random.Next(0, monsters.Length)];
            var heirMonster = new Monster();

            CopyMonster(heirMonster, monster);

            return heirMonster;
        }
        private static void CopyMonster(Monster heirMonster, Monster monster)
        {
            heirMonster.Coins = monster.Coins;
            heirMonster.Damage = monster.Damage;
            heirMonster.Defence = monster.Defence;
            heirMonster.ExperienceByKill = monster.ExperienceByKill;
            heirMonster.HealthPoint = monster.HealthPoint;
            heirMonster.MaxHealthPoint = monster.MaxHealthPoint;
            heirMonster.Name = monster.Name;
        }

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
                    ExperienceByKill = 75,
                    Coins = random.Next(1, 5)
                },
                new()
                {
                    Damage = 5,
                    Defence = 4,
                    HealthPoint = 35,
                    MaxHealthPoint = 35,
                    Name = "ХобГоблин",
                    ExperienceByKill = 100,
                    Coins = random.Next(5, 10)
                },
                new()
                {
                    Damage = 6,
                    Defence = 5,
                    HealthPoint = 50,
                    MaxHealthPoint = 50,
                    Name = "Орк",
                    ExperienceByKill = 125,
                    Coins = random.Next(7, 15)
                },
        };
    }
}
