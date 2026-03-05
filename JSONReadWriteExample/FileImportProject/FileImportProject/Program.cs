using System.Text.Json;

namespace FileImportProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------
            // INPUT: Load sorted.json
            // ----------------------------

            // Input file path (relative to runtime directory)
            string filePath = Path.Combine(
            AppContext.BaseDirectory,
            "JSON_Data",
            "sorted.json"
            );

            if (!File.Exists(filePath))
            {
                Console.WriteLine("sorted.json not found!");
                return;
            }

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
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

            // Output folder inside project root
            string outputDir = Path.Combine(projectRoot, "output");

            // Create folder if it doesn't exist
            Directory.CreateDirectory(outputDir);

            // Output file path
            string outputFile = Path.Combine(outputDir, "my_numbers.json");

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
