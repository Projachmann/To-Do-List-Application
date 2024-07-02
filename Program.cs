namespace Week_3_To_Do_List_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> toDoList = new List<string>();
            string input;
            bool noQuit = true;
            string filePath = "list.txt";

            LoadingFile();

            Console.WriteLine("Welcome to the To-Do application!");

            while (noQuit)
            {
                Console.WriteLine("You can add tasks, delete them, view them or quit the program. What do you want to do?");
                input = Console.ReadLine();
                switch (input)
                {
                    case "add":
                        Add();
                        break;
                    case "delete":
                        Delete();
                        break;
                    case "quit":
                        Quit();
                        break;
                    case "view":
                        View();
                        break;
                    default:
                        Console.WriteLine("Not a given option");
                        break;
                }
            }

            void Add()
            {
                string addingInput;
                Console.WriteLine("What do you want to add to your To-Do List?");
                addingInput = Console.ReadLine();
                toDoList.Add(addingInput);
            }

            void Delete()
            {
                int deletingInput;
                Console.WriteLine("What do you want to delete to your To-Do List?(Please input the number of the column)");
                deletingInput = Convert.ToInt32(Console.ReadLine());
                toDoList.RemoveAt(deletingInput - 1);
            }

            void View()
            {
                int positionNum = 1;

                Console.Clear();

                Console.WriteLine("Your to do List\n");
                foreach (string item in toDoList)
                {
                    Console.WriteLine($"{positionNum}. {item}");
                    positionNum++;
                }
                Console.WriteLine();
            }

            void Quit()
            {
                SavingFile();
                noQuit = false;
            }
            
            void SavingFile()
            {
                File.WriteAllLines(filePath, toDoList);
            }

            void LoadingFile()
            {
                if (File.Exists(filePath))
                {
                    List<string> loadedFile = new List<string>(File.ReadAllLines(filePath));
                    foreach (string item in loadedFile)
                    {
                        toDoList.Add(item);
                    }
                }
            }
        }
    }
}
