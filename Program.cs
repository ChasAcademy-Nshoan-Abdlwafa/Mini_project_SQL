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

        string menuMessage = " Hello and welcome to my SQL mini project. \n Please select an option: ";

        List<string> menuItems = new()
            {
                "Create a project",
                "Create a person",
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
                    CreateProject();
                    break;

                case 1:
                    Console.Clear();
                    CreatePerson();
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
        Console.WriteLine(string.Empty);

        Console.WriteLine(menuMessage);
        Console.WriteLine(string.Empty);

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

    private static void CreateProject() //This method is used to create a new project, adding it to the database
    {
        string? projectName;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n Please enter the name of the project that you would like to create: ");
            Console.Write(" \n Name of project: ");
            projectName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(projectName))
            {
                DBConnection.CreateProject(projectName);
                Console.WriteLine($"\n Success! {projectName} has been created and submitted to the database.");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\n ERROR: This input is invalid. Please try again. ");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
                break;
            }
        }
    }

    private static void CreatePerson() //This method is used to create a new person, adding it to the database
    {
        string? personName;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n Please enter the name of the person that you would like to create: ");
            Console.Write(" \n Name of person: ");
            personName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(personName))
            {
                DBConnection.CreatePerson(personName);
                Console.WriteLine($"\n Success! {personName} has been created and submitted to the database.");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\n ERROR: This input is invalid. Please try again. ");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
                break;
            }
        }
    }

    private static void TimeRegister() //This method is used to register hours worked on a project
    {
        string? personName;
        string? projectName;
        string? hoursWorked;

        List<ProjectModel> Projects = DBConnection.LoadProject();
        List<PersonModel> Persons = DBConnection.LoadPerson();

        Console.Clear();
        Console.WriteLine("\n Please enter the name of a person that you've created: ");
        Console.Write("\n Name of person: ");
        personName = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(personName))
        {
            Console.Clear();
            Console.WriteLine("\n Please enter the name of a project that you've created: ");
            Console.Write("\n Name of project: ");
            projectName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(projectName))
            {
                Console.Clear();
                Console.WriteLine("\n Please enter the time worked in whole hours: ");
                Console.Write("\n Hours worked: ");
                hoursWorked = Console.ReadLine();
                int.TryParse(hoursWorked, out int parsedHoursWorked);

                if (!string.IsNullOrWhiteSpace(hoursWorked) && parsedHoursWorked > 0)
                {
                    ProjectPersonModel model = new ProjectPersonModel()
                    {
                        //Looks through the lists until it finds the first entry that contains the same name, fulfilling the request
                        person_id = Persons.Where(person => person.person_name == personName).First().id, 
                        project_id = Projects.Where(project => project.project_name == projectName).First().id,
                        hours = parsedHoursWorked
                    };

                    DBConnection.AddHours(model);
                    Console.Clear();
                    Console.WriteLine($"\n Success! Time worked on project {projectName} by {personName} has been submitted to the database.");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\n ERROR: This input is invalid. Please try again. ");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\n ERROR: This input is invalid. Please try again. ");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"\n ERROR: This input is invalid. Please try again. ");
            Console.Write("\n Press any key to continue.");
            Console.ReadLine();
        }
    }

    private static void Exit() //Exits the application completely
    {
        Console.Clear();
        Console.WriteLine("\n Thank you for your time! Exiting application.");
        Environment.Exit(0);
    }
}