using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Реализация "прокачки"
    /// </summary>
    class LevelProgressing
    {
        // конструктор класса инициализирует начальные параметры героя
        public LevelProgressing()
        {
            CurrentExperience = 0;
            CurrentLevel = 1;
            ExperienceToNewLevel = 100;

            //ExpMultiplier = Multiplier;
        }

        //public void ImportInitialParameteres(int CurExp, int CurLvl, int ExpToNewLvl)
        //{
        //    CurrentExperience = CurExp;
        //    CurrentLevel = CurLvl;
        //    ExperienceToNewLevel = ExpToNewLvl;
        //}

        public int CurrentExperience { get;  set; }
        public int ExperienceToNewLevel { get;  set; }
        public int CurrentLevel { get;  set; }

        //public double ExpMultiplier { get; set; }

        public void GetLevelingInfo()
        {
            Console.WriteLine("Информация об уровне:");
            Console.WriteLine("Текущий уровень:          " + CurrentLevel);
            Console.WriteLine("Текущий опыт:             " + CurrentExperience);
            Console.WriteLine("До следующего уровня:     " + ExperienceToNewLevel);
            //Console.WriteLine("Exp. Multiplier: " + ExpMultiplier);
            Console.WriteLine();
        }


    }
}
