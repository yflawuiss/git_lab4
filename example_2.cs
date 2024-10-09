using System;

namespace example_2
{
    class Program
    {
        // Опис структури всередині класу але поза методами
        struct Lud
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
            // Створення екземпляру структури
            Lud lud = new Lud();

            // Змінні для зберігання значень
            string fLud;
            int grLud;
            char pLud;

            // Зчитування даних від користувача
            Console.Write("Введiть прiзвище: "); fLud = Console.ReadLine();
            
            Console.Write("Введiть рiк народження: ");
            while (!int.TryParse(Console.ReadLine(), out grLud) || grLud < 1900 || grLud > DateTime.Now.Year)
            {
                Console.Write("Невiрний рiк. Спробуйте ще раз: ");
            }

            Console.Write("Введiть стать (ч/ж): ");
            while (true)
            {
                pLud = Convert.ToChar(Console.ReadLine());
                if (pLud == 'ч' || pLud == 'ж')
                    break;
                Console.Write("Невiрна стать. Введiть «ч» або «ж»: ");
            }

            // Присвоєння значень полям структури
            lud.f = fLud;
            lud.gr = grLud;
            lud.p = pLud;

            // Виведення інформації
            Console.WriteLine($"Введенi данi: {lud.Vivod()}");
        }
    }
}