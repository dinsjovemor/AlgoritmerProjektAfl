using System.Security.Cryptography.X509Certificates;
using System.Text.Json; // tilføjer for at kunne serialize og deserialize

namespace AlgoritmerProjektAfl
{
    // "public" klasse, så den kan tilgås fra andre klasser
    public class Program
    {
        static void Main(string[] args)
        {
            // Her skal alle sorterings resultater gemmes i Json filen som export
            List<JsonExport> jsonExports = new List<JsonExport>();
            // "BaseDirectory" = her fortælles der selve mappenstien, hvor Json filerne ligger
            string projectRoot = Path.Combine(AppContext.BaseDirectory, "JSON FIL");
            // Dernæst indlæses de som tekst
            string notSorted = File.ReadAllText(Path.Combine(projectRoot, "notSorted.json"));
            string reverseSorted = File.ReadAllText(Path.Combine(projectRoot, "reverseSorted.json"));
            string sorted = File.ReadAllText(Path.Combine(projectRoot, "sorted.json"));

            // Køres BubbleSort og InsertionSort på alle tre filer. Resultaterne gemmesi JsonExports listen
            BubbleSortMyList("notSorted.json", notSorted, jsonExports);
            BubbleSortMyList("reverseSorted.json", reverseSorted, jsonExports);
            BubbleSortMyList("sorted.json", sorted, jsonExports);

            InsertionSortMyList("notSorted.json", notSorted, jsonExports);
            InsertionSortMyList("reverseSorted.json", reverseSorted, jsonExports);
            InsertionSortMyList("sorted.json", sorted, jsonExports);

            // Her oprettes en outputfil "my_numbers.json"
            string outputfile = Path.Combine(projectRoot, "my_numbers.json");
            // Her konverteres resultaterne til Json format som string-type, med en indrykning (bedre læsbarhed)
            string json = JsonSerializer.Serialize(jsonExports, new JsonSerializerOptions { WriteIndented = true });
            // Json-filen skrives med resultaterne
            File.WriteAllText(outputfile, json);



        }
        // 0: Metode, der
        // 1: indlæser data,
        // 2: sorterer med BubbleSort, samt
        // 3: gemmer resultaterne i jsonExports listen
        public static void BubbleSortMyList(string filename, string json, List<JsonExport> jsonExports)
        {
            // Opretter først en ny liste "myList" til at gemme tallene i
            MyList<int> myList = new MyList<int>();
            // Konverterer Json teksten til et C# objekt
            JsonValues data = JsonSerializer.Deserialize<JsonValues>(json);

            // If statement;
            // Hvis data ikke er null, så tilføjes tallene til "myList" og sorteres med BubbleSort
            if (data != null)
            {
                //Looper igennem hele array'et "values", én efter én
                for (int i = 0; i < data.values.Length; i++)
                {
                    //Tilføjer hvert tal til "myList" ved hjælp af Add-metoden
                    myList.Add(data.values[i]);

                }

                //notSortedMyList.BubbleSort();
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

    // Klassen viser resultaterne af sortingen i en JSON fil
    // Jeg beder om sorteringstype, filnavn, antal sammenligninger og de sorterede værdier.
    // Dette gør det nemt at analysere og sammenligne resultaterne af forskellige sorteringer på forskellige datasæt.
    public class JsonExport
    {
        public string sortType { get; set; }
        public string jsonFile { get; set; }

        public int comparisonCount { get; set; }
        public int[] sortedValues { get; set; }
    }
}
