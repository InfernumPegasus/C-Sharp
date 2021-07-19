using System;

namespace Game
{
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
        public override int Damage => 10;
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

    class Pistol : Weapon
    {
        public override int Damage => 6;

        public override void Fire()
        {
            Console.WriteLine("Pistol shoot!"); ;
        }

        public override void Reload()
        {
            Console.WriteLine("Pistol reloading!");
        }
    }
}
