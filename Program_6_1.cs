// 1 варіант

using System;

namespace Project_6
{
    internal class Program
    {
        [Flags]
        enum Disciplines
        {
            Not = 0b00000000,
            Philosophy = 0b00000001,
            Law = 0b00000010,
            ForeignLanguage = 0b00000100,
            ProgrammingBasics = 0b00001000,
            Databases = 0b00010000,
            InternetProgramming = 0b00100000,
            ComputerArchitecture = 0b01000000,
            HumanComputerInteraction = 0b10000000,
            CybersecurityBasics = 0b100000000,
            // Групуємо дисципліни за типом
            General = Philosophy | Law | ForeignLanguage,
            Required = ProgrammingBasics | Databases | InternetProgramming,
            Elective = ComputerArchitecture | HumanComputerInteraction | CybersecurityBasics
        }

        static void Main(string[] args)
        {
            Console.WriteLine("List of disciplines:");
            Console.WriteLine("1. Philosophy");
            Console.WriteLine("2. Law");
            Console.WriteLine("3. Foreign language");
            Console.WriteLine("4. Programming basics");
            Console.WriteLine("5. Databases");
            Console.WriteLine("6. Internet programming");
            Console.WriteLine("7. Computer architecture");
            Console.WriteLine("8. Human-computer interaction");
            Console.WriteLine("9. Cybersecurity basics");

            Console.WriteLine("Enter the numbers of disciplines you want to study (separated by commas):");
            string input = Console.ReadLine();
            string[] inputNumbers = input.Split(',');

            // Ініціалізуємо змінну, що містить вибрані дисципліни
            Disciplines selectedDisciplines = Disciplines.Not;
            // Проходимось по введених користувачем номерах дисциплін та додаємо їх до змінної
            foreach (string number in inputNumbers)
            {
                int disciplineNumber = Convert.ToInt16(number);
                int disciplineMask = (int)Math.Pow(2, disciplineNumber - 1);
                selectedDisciplines |= (Disciplines)disciplineMask;
            }

            Console.WriteLine("General disciplines:");
            Console.WriteLine((selectedDisciplines & Disciplines.General) != 0 ? (selectedDisciplines & Disciplines.General).ToString() : "None");

            Console.WriteLine("Required disciplines:");
            Console.WriteLine((selectedDisciplines & Disciplines.Required) != 0 ? (selectedDisciplines & Disciplines.Required).ToString() : "None");

            Console.WriteLine("Elective disciplines:");
            Console.WriteLine((selectedDisciplines & Disciplines.Elective) != 0 ? (selectedDisciplines & Disciplines.Elective).ToString() : "None");

            Console.WriteLine("Author: Sofiia Shevchenko");
            Console.ReadLine();
        }
    }
}
