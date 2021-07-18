using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Name = "Гоблин",
                    ExperienceByKill = 150
                },
                new()
                {
                    Damage = 5,
                    Defence = 4,
                    HealthPoint = 35,
                    Name = "ХобГоблин",
                    ExperienceByKill = 250
                },
                new()
                {
                    Damage = 6,
                    Defence = 5,
                    HealthPoint = 50,
                    Name = "Орк",
                    ExperienceByKill = 500
                }
            };

        // генератор монстра из пула monsters
        public static Monster GetRandomMonster()
        {
            return monsters[random.Next(0, monsters.Length)];
        }
    }
}
