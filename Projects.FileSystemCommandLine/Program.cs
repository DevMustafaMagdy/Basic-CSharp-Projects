namespace Projects.FileSystemCommandLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("<< ");
                var input = Console.ReadLine().Trim();
                var whiteSpaceIndex = input.IndexOf(' ');
                var command = input.Substring(0, whiteSpaceIndex).ToLower();
                var path = input.Substring(whiteSpaceIndex + 1).Trim();

                if (command == "list")
                {
                    foreach (var entry in Directory.GetDirectories(path))
                    {
                        Console.WriteLine($"\t[Dir] {entry[(entry.LastIndexOf('\\') + 1)..]}");
                    }
                    foreach (var entry in Directory.GetFiles(path))
                    {
                        Console.WriteLine($"\t[File] {entry[(entry.LastIndexOf('\\') + 1)..]}");
                    }
                }
                else if (command == "info")
                {
                    if (Directory.Exists(path))
                    {
                        var dirInfo = new DirectoryInfo(path);
                        Console.WriteLine("Type: Directory");
                        Console.WriteLine($"Created At {dirInfo.CreationTime}");
                        Console.WriteLine($"Last Modified At {dirInfo.LastWriteTime}");
                    }
                    if (File.Exists(path))
                    {
                        var fileInfo = new FileInfo(path);
                        Console.WriteLine("Type: File");
                        Console.WriteLine($"Created At {fileInfo.CreationTime}");
                        Console.WriteLine($"Last Modified At {fileInfo.LastWriteTime}");
                        Console.WriteLine($"Size is {fileInfo.Length / 1024} KB");
                    }
                }
                else if (command == "mkdir")
                {
                    if (Directory.Exists(path))
                    {
                        Console.WriteLine("Directory is already exist");
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                        Console.WriteLine("Successfully Created!");
                    }
                }
                else if (command == "remove")
                {
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path);
                        Console.WriteLine($"{path[(path.LastIndexOf('\\') + 1)..]} Deleted Successfully");
                    }
                    else if (File.Exists(path))
                    {
                        File.Delete(path);
                        Console.WriteLine($"{path[(path.LastIndexOf('\\') + 1)..]} Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Path");
                    }
                }
                else if (command == "print")
                {
                    if (File.Exists (path))
                    {
                        var content = File.ReadAllText(path);
                        Console.WriteLine(content);
                    }
                }
                else if (command == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command ! try again");
                }
            }
        }
    }
}
