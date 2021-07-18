using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Abilities
    {
        const float HEAL_COEFFICIENT = 0.33f;
        public static void HealPercent(Player player)
        {
            int heal = (int)(HEAL_COEFFICIENT * player.MaxHealthPoint);
            player.HealthPoint += heal;

            while (player.HealthPoint > player.MaxHealthPoint)
            {
                player.HealthPoint = player.MaxHealthPoint;
            }

            Console.WriteLine($"Вы восстановили {heal} очков жизни!");
        }

        //public static void DoubleDefence(Player player)
        //{

        //}
    }
}
