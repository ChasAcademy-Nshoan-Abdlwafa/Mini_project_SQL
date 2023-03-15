using System.Diagnostics;

namespace Mini_project_SQL;

class Program
{
    private static int menuIndex = 0;

    private static void Main(string[] args)
    {
        StartMenu();
    }

    private static void StartMenu()
    {
        Console.CursorVisible = false;

        string menuMessage = " Hello and welcome to my SQL mini project. \n Please select an option:";

        List<string> menuItems = new()
            {
                "Add a project",
                "Add a person",
                "Register time worked on a project",
                "Exit"
            };

        while (true)
        {
            int selectedMenuItem = DrawMenu(menuItems, menuMessage);
            switch (selectedMenuItem)
            {
                case 0:
                    Console.Clear();
                    AddProject();
                    break;

                case 1:
                    Console.Clear();
                    AddPerson();
                    break;

                case 2:
                    Console.Clear();
                    TimeRegister();
                    break;

                case 3:
                    Console.Clear();
                    Exit();
                    break;
            }
        }
    }

    private static int DrawMenu(List<string> menuItem, string menuMessage)
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

    private static void AddProject()
    {
        string? projectName;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n Please enter the name of the project that you would like to add: ");
            Console.Write(" \n ---> ");
            projectName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(projectName))
            {
                PostgresDataAccess.AddProject(projectName);
                Console.WriteLine($"\n Success! {projectName} has been added to the database.");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
                break;
            }
        }
    }

    private static void AddPerson()
    {
        string? personName;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n Please enter the name of the person that you would like to add: ");
            Console.Write(" \n ---> ");
            personName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(personName))
            {
                PostgresDataAccess.AddPerson(personName);
                Console.WriteLine($"\n Success! {personName} has been added to the database.");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
                break;
            }
        }
    }

    private static void TimeRegister()
    {
        Console.Clear();
    }

    private static void Exit()
    {
        Console.Clear();
        Console.WriteLine("\n Thank you for your time! Exiting application.");
        Environment.Exit(0);
    }
}
