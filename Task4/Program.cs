using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Students.dat";
            ReadBinary(path);
        }

        public static void ReadBinary(string pathFile) 
        {           
            
            BinaryFormatter binaryFormatter = new BinaryFormatter();       
          

            using (var fileStream = new FileStream(pathFile, FileMode.OpenOrCreate))
            {
                var student = (Student[])binaryFormatter.Deserialize(fileStream);
            }
        }
    }
}