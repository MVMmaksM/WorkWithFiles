namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к директории:");
            DirectoryInfo directoryInfo = new DirectoryInfo(Console.ReadLine());

            Console.WriteLine($"Размер директории: {GetDirSize(directoryInfo)}");
        }

        public static long GetDirSize(DirectoryInfo directory)
        {
            long dirSize = default;

            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo file in files)
            {
                dirSize += file.Length;
            }

            DirectoryInfo[] directories = directory.GetDirectories();

            foreach (var dir in directories)
            {
                dirSize += GetDirSize(dir);
            }

            return dirSize;
        }
    }
}