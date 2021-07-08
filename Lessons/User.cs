using System;

namespace User
{
    /// <summary>
    /// Класс для корректного ввода чисел типа int или double из входного потока
    /// </summary>
    class Input
    {
        /// <summary>
        /// Повторяет запрос на ввод числа типа int, пока то не будет удовлетворять требованиям этого типа
        /// </summary>
        /// <returns>
        /// Возвращает значение типа int из входного потока
        /// </returns>
        public static int GetInt()
        {
            string str;
            int num;
            bool isSuccess;
            do
            {
                Console.WriteLine("Введите корректное число:");
                str = Console.ReadLine();
                isSuccess = int.TryParse(str, out num);
            } while (!isSuccess || num > int.MaxValue || num < int.MinValue);

            return num;
        }

        /// <summary>
        /// Повторяет запрос на ввод числа типа double, пока то не будет удовлетворять требованиям этого типа
        /// </summary>
        /// <returns>
        /// Возвращает значение типа double из входного потока
        /// </returns>
        public static double GetDouble()
        {
            string str;
            double num;
            bool isSuccess;

            do
            {
                Console.WriteLine("Введите корректное число:");
                str = Console.ReadLine();
                isSuccess = double.TryParse(str, out num);
            } while (!isSuccess || num > double.MaxValue || num < double.MinValue);

            return num;
        }
    }
}
