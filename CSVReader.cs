using System;
using System.Collections.Generic;
using System.IO;

namespace File_QuickSort
{
    class CSVReader : IReader
    {
        public Dictionary<string, int> Data { get; private set; }
        string FilePath { set; get; }
        char SeperationChar { set; get; }
        public CSVReader(string Path)
        {
            FilePath = Path;
            SeperationChar = ',';
            Data = ReadFile(FilePath);
        }

        public Dictionary<string, int> ReadFile(string path)
        {
            if (path.Equals(""))
            {
                throw new FileNotFoundException("Wrong file path!");
            }

            Dictionary<string, int>  _data = new Dictionary<string, int>();
            StreamReader sReader = new StreamReader(path);
            // sReader.ReadLine();// remove header
            while (!sReader.EndOfStream)
            {
                var line = sReader.ReadLine();
                Console.WriteLine(line);
                var name = line.Split(SeperationChar)[0].Replace('"',' ').Trim();
                var id = line.Split(SeperationChar)[1].Replace('"', ' ').Trim();
                // _data.Add(name, Int32.Parse(id));
            }
            return _data;            
        }
    }
}
