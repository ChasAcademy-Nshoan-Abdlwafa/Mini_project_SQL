namespace Mini_project_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        static int menuIndex = 0;
        public static void StartMenu()
        {
            Console.CursorVisible = false;

            string menuMessage = "Welcome. Please select an option.";

            List<string> menuItems = new()
            {
                "Create a user",
                "Create a project",
                "Time report"
            };

            while (true)
            {
                int selectedMenuItem = DrawMenu(menuItems, menuMessage);
                switch (selectedMenuItem)
                {
                    case 0:
                        Console.Clear();
                        //CreateUser();
                        break;

                    case 1:
                        Console.Clear();
                        //CreateProject();
                        break;

                    case 2:
                        Console.Clear();
                        //TimeReport();
                        break;
                }
            }
        }

        public static int DrawMenu(List<string> menuItem, string menuMessage)
        {
            Console.Clear();
            Console.WriteLine("");

            Console.WriteLine(menuMessage);
            Console.WriteLine("");

            for (int i = 0; i < menuItem.Count; i++)
            {
                if (menuIndex == i)
                {
                    Console.WriteLine($"[{menuItem[i]}]");
                }
                else
                {
                    Console.WriteLine($" {menuItem[i]} ");
                }
            }

            ConsoleKeyInfo ckey = Console.ReadKey(); //Checks key input

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (menuIndex == menuItem.Count - 1) { }
                else { menuIndex++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (menuIndex <= 0) { }
                else { menuIndex--; }
            }
            else if (ckey.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.RightArrow)
            {
                return menuIndex;
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return menuIndex;
            }
            else
            {
                return 100;
            }

            return 100;
        }
    }
}