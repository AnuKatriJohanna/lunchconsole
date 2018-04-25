using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace lunchconsole
{
    class Program
    {
        private static LunchMenu _menu;
        public static LunchMenu Menu { get => _menu; set => _menu = value; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Kraftvaerk!");
            InitMenu();
            Console.WriteLine("Today's menu is {0} ", GetTodayMenu());

            AskAndPrintMenu();

            var quit = false;
            while (!quit)
            {
                Console.WriteLine("Press <M> for another day's menu. Or press <N> for a new menu. Quit with <Q>.");
                var cki = Console.ReadKey(true);
                switch (cki.Key)
                    {
                        case ConsoleKey.M :
                            AskAndPrintMenu();
                            break;
                        case ConsoleKey.N:
                            AskAndInitMenu();
                            break;
                        case ConsoleKey.Q:
                            quit = true;
                            break;
                        default:
                            break;
                    }
            } 
            
        }

        private static void AskAndInitMenu()
        {
            Console.WriteLine("Give a location and file name");
            var newFile = Console.ReadLine().ToString();
            if (!File.Exists(newFile))
            {
                Console.WriteLine("File does not exist. Using previous menu.");
                return;
            }
            try
            {
                var newMenu = new LunchMenu(newFile);
                if (newMenu.Menus.Count == 0)
                {
                    Console.WriteLine("Bad menufile. Using previous menu.");
                    return;
                }
                else
                {
                    Menu = newMenu;
                    Console.WriteLine("Using new menu.");
                    AskAndPrintMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
                return;
            }
            
        }

        private static void AskAndPrintMenu()
        {
            var userDay = "";
            bool validDay = false;
            while (!validDay)
            {
                Console.WriteLine("Give a valid day of week:");
                userDay = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());
                validDay = IsValidDay(userDay);
            }

            Console.WriteLine("On {0} we have {1}", userDay, GetMenu(userDay));
        }

        private static void InitMenu()
        {
            Menu = new LunchMenu("C:/Omat/Koodaukset/Kraftvaerk/lunchconsole/lunches.csv");
        }

        private static bool IsValidDay(string userDay)
        {
            return (Enum.TryParse(userDay, out DayOfWeek goodDay));
        }

        private static string GetTodayMenu()
        {
            var today = DateTime.Today.DayOfWeek.ToString();
            return GetMenu(today);
        }

        private static string GetMenu(string weekday)
        {
            return Menu.FindMenu(weekday);
        }
    }
}
