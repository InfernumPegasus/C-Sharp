using System;

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
        }

        public int CurrentExperience { get;  set; }
        public int ExperienceToNewLevel { get;  set; }
        public int CurrentLevel { get;  set; }

        public void GetLevelingInfo()
        {
            Console.WriteLine("Информация об уровне:");
            Console.WriteLine("Текущий уровень:          " + CurrentLevel);
            Console.WriteLine("Текущий опыт:             " + CurrentExperience);
            Console.WriteLine("До следующего уровня:     " + ExperienceToNewLevel);
            Console.WriteLine();
        }


    }
}
