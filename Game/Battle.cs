using System;

namespace Game
{
    static class Battle
    {
        private const int CRIT_DAMAGE_MULTIPLIER = 3;

        private static readonly Random random = new();
        private static bool IsCritical()
        {
            return random.Next(1, 10) == 1;
        }
        private static void Attack(GameEntity AttackEntity, GameEntity DefenceEntity)
        {
            if (DefenceEntity.HealthPoint > 0 && AttackEntity.HealthPoint > 0)
            {
                int damage = CalculateDamage(entity: AttackEntity, isCritical: IsCritical());

                if (damage > DefenceEntity.Defence)
                {
                    Console.WriteLine($"{AttackEntity.Name} наносит {Math.Abs(DefenceEntity.Defence - damage)} чистого ({damage}) урона {DefenceEntity.Name}!");
                    
                    /*
                     * Замена прямого изменения при помощи метода
                     */
                    DefenceEntity.GetHit(damage - DefenceEntity.Defence);
                }
                else
                    Console.WriteLine($"{AttackEntity.Name} не смог нанести вред {DefenceEntity.Name}!");

                if (DefenceEntity.HealthPoint <= 0)
                {
                    Console.WriteLine($"\n{DefenceEntity.Name} был повержен!");
                    Console.WriteLine($"Победитель: {AttackEntity.Name}!");
                    
                    return;
                }
            }
        }

        private static GameEntity EntitiesBattle(GameEntity AttackEntity, GameEntity DefenceEntity)
        {
            int round = 1;
            Console.WriteLine($"Битва {AttackEntity.Name} и {DefenceEntity.Name}!\n");
            do
            {
                /*
                 * Конструкция для логирования.
                 * При необходимости удалить.
                 */
                Console.WriteLine($"\nРаунд {round++}!\n");
                //AttackEntity.EntityInfo();
                //Console.WriteLine();
                //DefenceEntity.EntityInfo();

                //Thread.Sleep(1000);

                Attack(AttackEntity, DefenceEntity);
                Attack(DefenceEntity, AttackEntity);

            } while (AttackEntity.HealthPoint > 0 && DefenceEntity.HealthPoint > 0);

            if (AttackEntity.HealthPoint <= 0)
                return DefenceEntity;

            return AttackEntity;
        }

        public static void MonsterBattle(ref Player player)
        {
            Monster monster = Monster.GetRandomMonster();

            var winner = EntitiesBattle(AttackEntity: player, DefenceEntity: monster);

            if ( winner.GetType() == player.GetType() )
            {
                Console.WriteLine($"Вы получаете {monster.ExperienceByKill} опыта!\n");
                player.AddExperience(monster.ExperienceByKill);
            }
            else
            {
                Console.WriteLine("Вы проиграли! Производится выход из игры!");
                Environment.Exit(1);
            }

        }

        private static int CalculateDamage(GameEntity entity, bool isCritical)
        {
            if (isCritical)
            {
                Console.WriteLine("Критическое попадание!");
                return entity.Damage * CRIT_DAMAGE_MULTIPLIER;
            }

            return entity.Damage;
        }

    }
}
