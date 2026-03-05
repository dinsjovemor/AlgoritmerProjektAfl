using System.Text.Json;

namespace AlgoritmerProjektAfl
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------
            // INPUT: Load sorted.json
            // ----------------------------

            // Input file path (relative to runtime directory)
            string filePath = Path.Combine(
            AppContext.BaseDirectory,
            "JSON FIL",
            "sorted.json"
            );


            string json = File.ReadAllText(filePath);

            var data = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(json);

            List<int> numbers = data!["values"];

            Console.WriteLine($"Loaded {numbers.Count} numbers");
            Console.WriteLine($"First: {numbers[0]}");
            Console.WriteLine($"Last: {numbers[^1]}");

            // ----------------------------
            // OUTPUT: Save to project-root-relative output folder
            // ----------------------------











            // Compute project root (3 levels up from bin/Debug/net10.0)
            string projectRoot = Path.Combine(AppContext.BaseDirectory, "JSON FIL");
            string notSorted = File.ReadAllText(Path.Combine(projectRoot, "notSorted.json"));
            string reverseSorted = File.ReadAllText(Path.Combine(projectRoot, "reverseSorted.json"));
            string sorted = File.ReadAllText(Path.Combine(projectRoot, "sorted.json"));

            Console.WriteLine(notSorted);
            Console.WriteLine(reverseSorted);
            Console.WriteLine(sorted);









            // Output file path
            string outputFile = Path.Combine(projectRoot, "my_numbers.json");

            // Wrap list in JSON structure
            var outputData = new { values = numbers };

            // Serialize JSON with indentation
            string newJson = JsonSerializer.Serialize(
                outputData,
                new JsonSerializerOptions { WriteIndented = true }
            );

            // Write JSON to file
            File.WriteAllText(outputFile, newJson);

            Console.WriteLine($"Saved JSON to: {outputFile}");


        }
    }
}
