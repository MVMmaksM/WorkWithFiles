namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке:");
            DeleteFile(Console.ReadLine());
        }

        public static void DeleteFile(string pathDirectory)
        {
            if (string.IsNullOrWhiteSpace(pathDirectory))
            {
                Console.WriteLine("Пустой путь!");
                return;
            }

            if (!Directory.Exists(pathDirectory))
            {
                Console.WriteLine($"Директория по пути: {pathDirectory} отсутствует!");
            }
            else
            {
                var files = Directory.GetFiles(pathDirectory);

                foreach (var file in files)
                {
                    if ((DateTime.Now - File.GetLastWriteTime(file)) >= TimeSpan.FromMinutes(30))
                    {
                        File.Delete(file);
                    }
                }
            }
        }
    }
}