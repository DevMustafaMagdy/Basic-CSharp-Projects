namespace Projects.TaskTracker
{
    internal class Program
    {
        static string[] Tasks = new string[100];
        static int Index = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Your Task Tracker");
            Console.WriteLine("--------------------------");

            while (true)
            {
                Console.WriteLine("Choose from 1 to 6");
                Console.WriteLine("1- Add Task\n2- View Tasks\n3- Delete Task\n4- Edit Task\n5- Mark Complete\n6- Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        EditTask();
                        break;
                    case "5":
                        MarkComplete();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please Enter only Number from 1 to 6");
                        break;
                }
            }
        }
        static void AddTask()
        {
            Console.Write("Enter the task you want to add: ");
            var task = Console.ReadLine();
            Tasks[Index++] = task;
            Console.WriteLine("--------Added Successfully--------");
            Console.Write("Do you want to add another Task Y/N?: ");
            var userAnswer = Console.ReadLine().ToLower();
            if (userAnswer == "y")
            {
                AddTask();
            }
        }
        static void ViewTasks()
        {
            for (int i = 0; i < Index; i++)
            {
                Console.WriteLine($"{i + 1}- {Tasks[i]}");
            }
        }
        static void DeleteTask()
        {
            Console.Write("Enter the number of task you want to delete: ");
            int taskNumber = int.Parse(Console.ReadLine());
            if(taskNumber <= Index)
            {
                Tasks[taskNumber - 1] = "[Deleted]";
                Console.WriteLine("--------Deleted Successfully--------");

            }
            else
            {
                Console.WriteLine("Invalid Number!");
            }
        }
        static void EditTask()
        {
            Console.Write("Enter the number of task you want to edit: ");
            var taskNumber = int.Parse(Console.ReadLine());
            if(taskNumber <= Index)
            {
                Console.Write("Write new task: ");
                var newTask = Console.ReadLine();
                Tasks[taskNumber - 1] = newTask;
                Console.WriteLine("--------Edited Successfully--------");
            }
            else
            {
                Console.WriteLine("Invalid Number!");
            }
        }
        static void MarkComplete()
        {
            Console.Write("Enter the completed task number: ");
            int taskNumber = int.Parse(Console.ReadLine());
            if(taskNumber <= Index)
            {
                Tasks[taskNumber - 1] += " --[Completed]";
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }

        }
    }
}
