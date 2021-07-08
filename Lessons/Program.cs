using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;


namespace Lessons
{
    class Player
    {
        public void Reload(Weapon weapon)
        {
            weapon.Reload();
        }
        public void Fire(Weapon weapon)
        {
            weapon.Fire();
        }

        public void CheckInfo(Weapon weapon)
        {
            weapon.ShowInfo();
        }
    }

    abstract class Weapon
    {
        public abstract int Damage { get; }
        public abstract void Reload();
        public abstract void Fire();

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {GetType().Name}\nDamage: {Damage}");
        }
    }
    class Bow : Weapon
    {
        public override int Damage { get { return 3; } }
        public override void Reload()
        {
            Console.WriteLine("Reloading Bow!");
        }
        public override void Fire()
        {
            Console.WriteLine("Shoot!");
        }
    }

    class LaserGun : Weapon
    {
        public override int Damage { get { return 10; } }
        public override void Reload()
        {
            Console.WriteLine("Reloading Lasergun!");
        }
        public override void Fire()
        {
            Console.WriteLine("Laser shoot!");
        }
    }

    class Crossbow : Weapon
    {
        public override int Damage => 5;
        public override void Reload()
        {
            Console.WriteLine("Reloading crossbow!");
        }
        public override void Fire()
        {
            Console.WriteLine("Crossbow shoot");
        }
    }

    class Rifle : Weapon
    {
        public override int Damage => 12;

        public override void Fire()
        {
            Console.WriteLine("Rifle shoot!");
        }

        public override void Reload()
        {
            Console.WriteLine("Reloading rifle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            
            Weapon[] inventory = { new Bow(), new Crossbow(), new LaserGun(), new Rifle() };
            foreach (var item in inventory)
            {
                player.CheckInfo(item);
                player.Reload(item);
                player.Fire(item);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

    }
}
