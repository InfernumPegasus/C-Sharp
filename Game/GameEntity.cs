using System;

namespace Game
{
    /// <summary>
    /// Реализация сущностей
    /// </summary>
    public class GameEntity
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int HealthPoint { get; protected set; }
        public int MaxHealthPoint { get; protected set; }
        public int Defence { get; protected set; }

        public void EntityInfo()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine("Защита:   " + Defence);
            Console.WriteLine("урон:     " + Damage);
            Console.WriteLine("HP:       " + HealthPoint);
            Console.WriteLine("Макс. HP: " + MaxHealthPoint);
        }

        public void GetHit(int damage)
        {
            if (damage <= 0)
            {
                Console.WriteLine("Некорректное значение!");
                return;
            }

            HealthPoint -= damage;
        }

        protected void GetHeal(int heal)
        {
            if (heal <= 0)
            {
                Console.WriteLine("Некорректное значение!");
                return;
            }

            HealthPoint += heal;
            if (HealthPoint > MaxHealthPoint)
                HealthPoint = MaxHealthPoint;
        }

        protected void GetDefence(int defence)
        {
            if (defence <= 0)
            {
                Console.WriteLine("Некорректное значение!");
                return;
            }

            Defence += defence;
        }

        protected void GetAddedDamage(int damage)
        {
            if (damage < 0)
            {
                Console.WriteLine("Некорректное значение!");
                return;
            }

            Damage += damage;
        }

        // АБИЛКИ ПЕРЕНЕСТИ В КЛАСС

        const int HEAL_COEFFICIENT = 3;
        const int DEFENCE_MULTIPLIER = 2;
        const int DAMAGE_MULTIPLIER = 2;

        const int AVIABLE_ABILITIES = 3;

        private int AbilitiesAviable = AVIABLE_ABILITIES;

        private bool HasAnyDefenceBuff = false;
        private bool HasAnyDamageBuff = false;

        protected void ShowFreeAbilitiesNumber()
        {
            Console.WriteLine($"{Name} может использовать умения {AbilitiesAviable}-ы.");
        }

        protected void ShowNoAbilitiesMessage()
        {
            Console.WriteLine($"У {Name} не осталось доступных способностей!");
        }

        public void ChooseBuff()
        {
            ShowFreeAbilitiesNumber();
            Console.WriteLine("Доступные эффекты:");
            Console.WriteLine("1 - Лечение на треть от максимального запаса жизни.");
            Console.WriteLine("2 - Получить +100% к защите.");
            Console.WriteLine("3 - Получить +100% к урону.");


            switch ( Console.ReadKey().Key )
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Heal();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    IncreaseDefence();
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    IncreaseDamage();
                    break;
                
                default:
                    Console.Clear();
                    break;
            }

        }
        private void Heal()
        {
            const string AbilityName = "Лечение";

            if (AbilitiesAviable > 0)
            {
                AbilitiesAviable--;
                Console.WriteLine($"{Name} использовал способность {AbilityName}.");
                Console.WriteLine();
                ShowFreeAbilitiesNumber();

                int heal = MaxHealthPoint / HEAL_COEFFICIENT;
                GetHeal(heal);
                Console.WriteLine($"{Name} излечился на {heal} очков здоровья!");
            }
            else
                ShowNoAbilitiesMessage();
        }

        private void IncreaseDefence()
        {
            const string AbilityName = "Железная кожа";

            if (AbilitiesAviable > 0 && !HasAnyDefenceBuff)
            {
                AbilitiesAviable--;
                HasAnyDefenceBuff = true;
                Console.WriteLine($"{Name} использовал способность {AbilityName}.");
                Console.WriteLine();
                ShowFreeAbilitiesNumber();

                int defence = DEFENCE_MULTIPLIER * Defence;
                GetDefence(defence);
                Console.WriteLine($"{Name} обрел броню на {defence} очков защиты!");
            }
            else
                ShowNoAbilitiesMessage();
        }

        private void IncreaseDamage()
        {
            const string AbilityName = "Ярость";

            if (AbilitiesAviable > 0 && !HasAnyDamageBuff)
            {
                AbilitiesAviable--;
                HasAnyDamageBuff = true;
                Console.WriteLine($"{Name} использовал способность {AbilityName}.");
                Console.WriteLine();
                ShowFreeAbilitiesNumber();

                int damage = DAMAGE_MULTIPLIER * Damage;
                GetAddedDamage(damage);
                Console.WriteLine($"{Name} увеличил урон на {damage} очков!");
            }
            else
                ShowNoAbilitiesMessage();
        }

    }

}
