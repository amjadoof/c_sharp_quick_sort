using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sorting is based on keys! file contint shoul be as follows, with no duplicate keys ");
            Console.WriteLine("\"a\",9\n\"b\", 8");
            PrintMenu();
            string Path = @"d:\test\data.csv";
            Dictionary<string, int> fileContent = null;
            OrderedDictionary od = null;
            while (true)
            {
                Console.Write("Enter your choise: ");
                var choise = Console.ReadLine();
                switch (choise.Trim().ToLower()){
                    case "q": break;
                    case "1":
                        Path = readFilePath();
                        fileContent = ReadCSV(Path, ',');
                        break;
                    case "2":
                        od = SortDictionary(fileContent, true);
                        PrintDictionary(od);
                        break;
                    case "3":
                        od = SortDictionary(fileContent, false);
                        PrintDictionary(od);
                        break;
                    case "4":
                        if (fileContent != null)
                        {
                            PrintDictionary(fileContent);
                        }else
                        {
                            Console.WriteLine("Wrong file path, please set a file path");
                        }
                        break;
                    case "5":
                        fileContent = ReadCSV(Path, ',');
                        break;
                    case "6":
                        PrintDictionary(od);
                        break;
                    default:
                        Console.WriteLine("Wrong command, chose one of the following:");
                        PrintMenu();
                        break;
                }
                if (choise.ToLower().Equals("q"))
                {
                    break;
                }
            }
            // test();            
            Console.WriteLine("\nPress any key to stop execution.");
            Console.ReadKey();
        }

        private static void PrintDictionary(OrderedDictionary od)
        {
            Console.WriteLine("Name, Id");
            foreach (var key in od.Keys)
            {
                Console.WriteLine(key + ", " + od[key]);
            }
        }

        private static OrderedDictionary SortDictionary(Dictionary<string, int> fileContent, bool asc)
        {
            string[] keys = fileContent.Keys.ToArray();
            QSort(keys, 0, keys.Length - 1, asc);
            PrintArray(keys);
            OrderedDictionary v = new OrderedDictionary(fileContent.Count);
            //foreach(var k in keys)
            //{
            //    v.Add(k, fileContent[k]);
            //}
            return v;
        }

        private static void PrintDictionary(Dictionary<string, int> fileContent)
        {
            Console.WriteLine("Name, Id");
            foreach (var pain in fileContent)
            {
                Console.WriteLine(pain.Key+", "+ pain.Value);
            }
        }

        private static Dictionary<string, int> ReadCSV(string path, char SeperationChar, bool WithHeader = false)
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            StreamReader sReader = new StreamReader(path);
            if (WithHeader)
            {
                sReader.ReadLine();
            }
            while (!sReader.EndOfStream)
            {
                var line = sReader.ReadLine();
                var name = line.Split(SeperationChar)[0].Replace('"', ' ').Trim();
                var id = line.Split(SeperationChar)[1].Replace('"', ' ').Trim();
                // Console.WriteLine(line);
                try
                {
                    data.Add(name, Int32.Parse(id));
                } catch (ArgumentException a)
                {
                    Console.WriteLine("File contains duplicate keys");
                    break;
                }
            }
            return data;
        }

        private static string readFilePath()
        {
            Console.Write("Please enter file path: ");
            string s = Console.ReadLine();
            Console.WriteLine("File path is set to " + s.Trim());
            return s.Trim();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1 : Add file path");
            Console.WriteLine("2 : Sort Asc");
            Console.WriteLine("3 : Sort Desc");
            Console.WriteLine("4 : Print File");
            Console.WriteLine("q : exit program");
            Console.WriteLine("====================");
        }

        private static void test()
        {
            int[] arr = { 10, 7, 5, -1 };
            QSort(arr, 0, arr.Length - 1, true);
            PrintArray(arr);
            Console.WriteLine();
            QSort(arr, 0, arr.Length - 1, false);
            PrintArray(arr);

            var a = new[] { "a", "b", "c" };
            Console.WriteLine();
            QSort(a, 0, a.Length - 1, true);
            PrintArray(a);
            Console.WriteLine();
            QSort(a, 0, a.Length - 1, false);
            PrintArray(a);
        }

        private static void PrintArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
                
        private static void QSort<T>(T[] array, int left, int right, bool asc) where T : IComparable<T>
        {
            if (left < right)
            {
                // pivot is partitioning index
                int pivot = Partition(array, left, right, asc);

                QSort(array, left, pivot - 1, asc);
                QSort(array, pivot, right, asc);
            }
        }                

        private static int Partition<T>(T[] array, int left, int right, bool asc) where T : IComparable<T>
        {
            var pivot = array[right];

            // index of smallest element
            int i = (left - 1);
            for (int j = left; j < right; j++)
            {
                if (asc) {
                    if (array[j].CompareTo(pivot) <= 0)// 
                    {
                        i++;
                        // swap array[i] and array[j] 
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
                else 
                {
                    if (array[j].CompareTo(pivot)>=0)
                    {
                        i++;
                        // swap array[i] and array[j] 
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            var temp1 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp1;
            return i + 1;
        }
    }        
}
