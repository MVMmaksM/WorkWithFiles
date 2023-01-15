namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к директории:");
            
            string pathDirectory = Console.ReadLine();
           
            DirectoryInfo directoryInfo = new DirectoryInfo(pathDirectory);

            long sizeDirAfterDel = Task2.Program.GetDirSize(directoryInfo);

            Console.WriteLine($"Размер директории до удаления файлов: {sizeDirAfterDel}");

            long countAfterDel = GetCountFile(directoryInfo);

            Task1.Program.DeleteFile(pathDirectory);

            long sizeDirBeforeDel = Task2.Program.GetDirSize(directoryInfo);

            long countBeforeDel = GetCountFile(directoryInfo);

            Console.WriteLine($"Удалено файлов: {countAfterDel-countBeforeDel}");

            Console.WriteLine($"Размер директории после удаления файлов: {sizeDirBeforeDel}");

            Console.WriteLine($"Освобождено места: {sizeDirAfterDel - sizeDirBeforeDel}");
        }

        public static long GetCountFile (DirectoryInfo directory)
        {
            long countFiles = default;

            FileInfo[] files = directory.GetFiles();

            countFiles += files.Length;

            DirectoryInfo[] directories = directory.GetDirectories();

            foreach (var dir in directories)
            {
                countFiles += GetCountFile(dir);
            }

            return countFiles;
        }
    }
}