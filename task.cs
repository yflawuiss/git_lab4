using System;
using System.Collections.Generic;

namespace task
{
    struct Meteo
    {
        public string DayOfWeek;  // День тижня
        public int Temperature;   // Температура
        public int Precipitation; // Опади (0, якщо опадів немає)

        // Конструктор для ініціалізації полів
        public Meteo(string dayOfWeek, int temperature, int precipitation)
        {
            DayOfWeek = dayOfWeek;
            Temperature = temperature;
            Precipitation = precipitation;
        }

        // Метод для виводу інформації про день
        public string Display()
        {
            return $"{DayOfWeek}: Температура {Temperature}°C, опади {Precipitation} мм";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Meteo> weatherData = new List<Meteo>();
            List<string> enteredDays = new List<string>();  // Для зберігання вже введених днів тижня

            // Заголовок
            Console.WriteLine("      <~<~ Введення даних про погоду 5 днiв тижня ~>~>");

            // Завдання 1: Введення даних з клавіатури (максимум 5 днів)
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\n{i} день для даних:");

                string dayOfWeek;
                while (true)
                {
                    Console.Write("День тижня (числа 1-7): ");
                    int day;
                    if (int.TryParse(Console.ReadLine(), out day) && day > 0 && day <= 7)
                    {
                        dayOfWeek = "  день " + day;
                        if (!enteredDays.Contains(dayOfWeek))  // Перевірка на наявність існуючого введеного дня
                        {
                            enteredDays.Add(dayOfWeek);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Цей день тижня вже описано. Введiть iнший день.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невiрний день тижня. Введiть число вiд 1 до 7");
                    }
                }

                Console.Write("Температура: ");
                int temperature;
                while (!int.TryParse(Console.ReadLine(), out temperature))
                {
                    Console.Write("Введiть числове значення для температури: ");
                }

                Console.Write("Опади (мм, 0 якщо немає): ");
                int precipitation;
                while (!int.TryParse(Console.ReadLine(), out precipitation) || precipitation < 0)
                {
                    Console.Write("Кiлькiсть опадiв не може бути вiд'ємною: ");
                }

                // Додавання даних у список
                weatherData.Add(new Meteo(dayOfWeek, temperature, precipitation));
            }

            // Виведення заголовків таблиці
            Console.WriteLine("\n       << Введенi данi про погоду >>");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(string.Format("{0,-14} {1,-14} {2,-14}", "День тижня", "Температура", "Опади")); // Форматування заголовків
            Console.WriteLine("-------------------------------------------");

            // Виведення списку
            foreach (Meteo day in weatherData)
            {
                Console.WriteLine(string.Format("{0,-14} {1,-14} {2,-14}", day.DayOfWeek, day.Temperature, day.Precipitation)); // Форматування значень
            }

            // Завдання 2: Підрахунок днів із снігом
            int snowDaysCount = 0;
            foreach (Meteo day in weatherData)
            {
                if (day.Temperature <= 0 && day.Precipitation > 0)
                {
                    snowDaysCount++;
                }
            }
            Console.WriteLine($"\nКiлькiсть днiв, коли йшов снiг: {snowDaysCount}");

            // Завдання 3: Загальна кількість опадів у дощові дні
            int totalRainPrecipitation = 0;
            foreach (Meteo day in weatherData)
            {
                if (day.Temperature > 0)
                {
                    totalRainPrecipitation += day.Precipitation;
                }
            }
            Console.WriteLine($"Загальна кiлькiсть опадiв у дощовi днi: {totalRainPrecipitation} мм");

            // Завдання 4: Середня температура за тиждень
            double averageTemperature = 0;
            foreach (Meteo day in weatherData)
            {
                averageTemperature += day.Temperature;
            }
            averageTemperature /= weatherData.Count;
            Console.WriteLine($"Середня температура за тиждень: {averageTemperature:F2}°C");
        }
    }
}