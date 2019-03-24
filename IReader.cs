using System.Collections.Generic;

namespace File_QuickSort
{
    public interface IReader
    {
        Dictionary<string, int> ReadFile(string path);
    }
}
