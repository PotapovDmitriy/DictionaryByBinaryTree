using System.IO;

namespace DictionaryByBinaryTree
{
    public class FileService : IFileService
    {
        public void WriteToFile(string path, string content, bool isClose = true)
        {
            // File.WriteAllText(path, content);

            var stream = new StreamWriter(path);
            stream.Write(content);
            
            if (isClose)
                stream.Close();
        }

        public string? ReadFromFile(string path, bool isClose = true)
        {
            // return File.ReadAllText(path);
            var stream = new StreamReader(path);
            var content = stream.ReadLine();
            if (isClose)
                stream.Close();

            return content;
        }
    }
}