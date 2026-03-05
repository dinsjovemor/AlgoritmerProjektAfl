using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace AlgoritmerProjektAfl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<JsonExport> jsonExports = new List<JsonExport>();
            // Compute project root (3 levels up from bin/Debug/net10.0)
            string projectRoot = Path.Combine(AppContext.BaseDirectory, "JSON FIL");
            string notSorted = File.ReadAllText(Path.Combine(projectRoot, "notSorted.json"));
            string reverseSorted = File.ReadAllText(Path.Combine(projectRoot, "reverseSorted.json"));
            string sorted = File.ReadAllText(Path.Combine(projectRoot, "sorted.json"));

                      

            BubbleSortMyList("notSorted.json", notSorted, jsonExports);
            BubbleSortMyList("reverseSorted.json", reverseSorted, jsonExports);
            BubbleSortMyList("sorted.json", sorted, jsonExports);

            InsertionSortMyList("notSorted.json", notSorted, jsonExports);
            InsertionSortMyList("reverseSorted.json", reverseSorted, jsonExports);
            InsertionSortMyList("sorted.json", sorted, jsonExports);

            string outputfile = Path.Combine(projectRoot, "my_numbers.json");
            string json = JsonSerializer.Serialize(jsonExports, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(outputfile, json);



        }
        public static void BubbleSortMyList(string filename, string json, List<JsonExport> jsonExports)
        {
            MyList<int> myList = new MyList<int>();
            JsonValues data = JsonSerializer.Deserialize<JsonValues>(json);

            if (data != null)
            {

                for (int i = 0; i < data.values.Length; i++)
                {
                    myList.Add(data.values[i]);

                }

                //notSortedMyList.InsertionSort();
                myList.BubbleSort();

                for (int i = 0; i < myList.Count; i++)
                {
                    Console.WriteLine(myList[i]);
                }

                Console.WriteLine($"FINISHED INSERTION SORT WITH COMPARISONCOUNT: {myList.comparisonCount}");
            }

            int[] intArray = new int[myList.Count];
            for(int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = myList[i];
            }
            JsonExport jsonExport = new JsonExport { jsonFile=filename, sortType="BubbleSort", comparisonCount = myList.comparisonCount, sortedValues = intArray };
            jsonExports.Add(jsonExport);
        }

        public static void InsertionSortMyList(string filename, string json, List<JsonExport> jsonExports)
        {
            MyList<int> myList = new MyList<int>();
            JsonValues data = JsonSerializer.Deserialize<JsonValues>(json);

            if (data != null)
            {

                for (int i = 0; i < data.values.Length; i++)
                {
                    myList.Add(data.values[i]);

                }

                //notSortedMyList.InsertionSort();
                myList.InsertionSort();

                for (int i = 0; i < myList.Count; i++)
                {
                    Console.WriteLine(myList[i]);
                }

                Console.WriteLine($"FINISHED INSERTION SORT WITH COMPARISONCOUNT: {myList.comparisonCount}");
            }

            int[] intArray = new int[myList.Count];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = myList[i];
            }
            JsonExport jsonExport = new JsonExport { jsonFile = filename, sortType = "InsertionSort", comparisonCount = myList.comparisonCount, sortedValues = intArray };
            jsonExports.Add(jsonExport);
        }

    }
    public class JsonValues
    {
        public int[] values { get; set; }
    }

    public class JsonExport
    {
        public string sortType { get; set; }
        public string jsonFile { get; set; }

        public int comparisonCount { get; set; }
        public int[] sortedValues { get; set; }
    }
}
