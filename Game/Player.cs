using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : GameEntity
    {
        private const int NEW_LEVEL_HP = 5;
        private const int DELEVEL_EXP = -100;
        private const int NEW_LEVEL_EXP = 100;

        // конструктор класса
        public Player()
        {
            Name = "Kradar";
            Damage = 6;
            HealthPoint = 50;
            MaxHealthPoint = 50;
            Defence = 5;

            Progress = new();
        }

        public void GetPlayerInfo()
        {
            EntityInfo();
            Console.WriteLine("Макс. HP: " + MaxHealthPoint);
        }

        private static void CalculateLevelRequirements(LevelProgressing progress, bool isDelevel)
        {
            if (isDelevel)
            {
                if (progress.CurrentLevel > 0)
                {
                    progress.ExperienceToNewLevel -= NEW_LEVEL_EXP;
                    progress.CurrentExperience = (int)(0.5 * progress.ExperienceToNewLevel);
                }
                else
                {
                    progress.CurrentLevel = 0;
                    progress.CurrentExperience = 0;
                    progress.ExperienceToNewLevel = NEW_LEVEL_EXP;
                }
            }
            else
            {
                progress.ExperienceToNewLevel += NEW_LEVEL_EXP;
            }

            if (progress.ExperienceToNewLevel < NEW_LEVEL_EXP)
            {
                progress.ExperienceToNewLevel = NEW_LEVEL_EXP;
            }
        }

        public void AddExperience(int gainedExperience)
        {
            Progress.CurrentExperience += gainedExperience;

            while (Progress.CurrentExperience >= Progress.ExperienceToNewLevel)
            {
                Progress.CurrentExperience -= Progress.ExperienceToNewLevel;
                Progress.CurrentLevel++;
                CalculateLevelRequirements(Progress, isDelevel: false);
                CalculateMaxHealthPoint(isDelevel: false);
            }

            while (Progress.CurrentExperience <= DELEVEL_EXP)
            {
                Progress.CurrentLevel--;
                CalculateLevelRequirements(Progress, isDelevel: true);
                CalculateMaxHealthPoint(isDelevel: true);
            }
        }

        private void CalculateMaxHealthPoint(bool isDelevel)
        {
            if (isDelevel == true && Progress.CurrentLevel > 0)
                MaxHealthPoint -= NEW_LEVEL_HP;   
            else
                MaxHealthPoint += NEW_LEVEL_HP;

            HealthPoint = MaxHealthPoint;
        }

        // описание "прокачки"
        public LevelProgressing Progress { get; protected set; }

        //public void ImportInitialParameteres(string name, int dmg, int hp, int maxHP, int def)
        //{
        //    Name = name;
        //    Damage = dmg;
        //    HealthPoint = hp;
        //    MaxHealthPoint = maxHP;
        //    Defence = def;
        //}

    }
}
