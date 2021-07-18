using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Реализация сущностей
    /// </summary>
    public class GameEntity
    {
        public string Name { get; protected set; }

        public int Damage { get; protected set; }
        public int HealthPoint { get; set; }
        public int MaxHealthPoint { get; set; }
        public int Defence { get; protected set; }


        public void EntityInfo()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine("Защита:  " + Defence);
            Console.WriteLine("урон:    " + Damage);
            Console.WriteLine("HP:      " + HealthPoint);
        }

    }

}
