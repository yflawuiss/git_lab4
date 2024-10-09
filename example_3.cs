using System;

namespace example_3
{
    class Program
    {
        
        struct Lud  // Опис структури
        {
            // Поля
            public string f;  // Прізвище 
            public int gr;  // Рік народження
            public char p;  // Стать (ч/ж)

            // Метод
            public string Vivod()
            {
                string s = f + " " + Convert.ToString(gr) + " " + Convert.ToString(p);
                return s;
            }
        }

        static void Main(string[] args)
        {
            // Список студентів
            List<Lud> students = new List<Lud>();
            // Опис змінної для введення, без іниціалізації полів
            Lud stud;
            // Використовуємо конструктор, для іниціалізації полів
            // Опис змінної для запам'ятовування наймолодшого
            Lud mx = new Lud();
            int n = 4;  // Кількість студентів
            Console.WriteLine("Введiть данi: ");
            // Ввод і заповнення списку
            for (int i = 0; i < n; i++)
            {
                // Заповнення полей структури
                stud.f = Console.ReadLine();
                stud.gr = Convert.ToInt32(Console.ReadLine());
                stud.p = Convert.ToChar(Console.ReadLine());
                students.Add(stud);
            }
            Console.WriteLine("Список студентiв:");

            // Виведення списку на екран
            for (int i = 0; i < n; i++)
            {
                // Застосування методу структури
                Console.WriteLine(students[i].Vivod());
            }

            // Перегляд списка і надходження наймолодшої студентки
            for (int i = 0; i < n; i++)
            {
                if (students[i].p == 'ж' &&
                   (students[i].gr == 0 || students[i].gr > mx.gr)) mx = students[i];
            }

            // Виведення на екран
            if (mx.gr != 0)
                Console.WriteLine("\nНаймолодша студентка: {0} {1} {2}", mx.f, mx.gr, mx.p);
            else Console.WriteLine("\nНемає дiвчин.");
            Console.ReadKey();
        }
    }
}