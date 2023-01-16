using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathFile = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Students.dat";
            string pathDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Students";
            CreateDirecroty(pathDirectory);
            WriteStudents(ReadBinary(pathFile), pathDirectory);
        }

        public static void CreateDirecroty(string pathDirectory)
        {
            if (!Directory.Exists(pathDirectory))
            {
                Directory.CreateDirectory(pathDirectory);
            }
        }

        public static Student[] ReadBinary(string pathFile)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Student[] students;

            using (var fileStream = new FileStream(pathFile, FileMode.OpenOrCreate))
            {
                students = (Student[])binaryFormatter.Deserialize(fileStream);
            }

            return students;
        }

        public static void WriteStudents(Student[] students, string pathDirectory) 
        {          
            foreach (var student in students)
            {
                if (!File.Exists($"{pathDirectory}\\{student.Group}.txt"))
                {
                    using (StreamWriter streamWrite = File.CreateText($"{pathDirectory}\\{student.Group}.txt"))
                    {
                        streamWrite.WriteLine($"{student.Name} {student.DateOfBirth.Date.ToShortDateString()}");
                    }
                }
                else
                {
                    using (StreamWriter streamWrite = new FileInfo($"{pathDirectory}\\{student.Group}.txt").AppendText())
                    {
                        streamWrite.WriteLine($"{student.Name} {student.DateOfBirth.ToShortDateString()}");
                    }
                }
            }
        }
    }
}