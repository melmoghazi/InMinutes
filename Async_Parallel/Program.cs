using System.Text.Json;

namespace Async_Parallel
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Start Async Methods");
            //var bahrain = new Program().ReadBahrainCountry();
            //var iraq = new Program().ReadIraqCountry();
            //Console.WriteLine(bahrain.Result.Name_En);
            //Console.WriteLine(iraq.Result.Name_En);
            //Console.WriteLine("End Async Methods");

            //Console.WriteLine("--------------------------------------------------");

            //Console.WriteLine("Start Async await Task.WhenAll");
            //var results = new Program().ReadCountriesAsync();
            //Console.WriteLine("Bahrain: " + JsonSerializer.Deserialize<Country>(results.Result[0]).Name_En);
            //Console.WriteLine("Iraq: " + JsonSerializer.Deserialize<Country>(results.Result[1]).Name_En);
            //Console.WriteLine("End Async await Task.WhenAll");

            //Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Hello, Parallel!");
            new Program().ReadDataInParallel();
            Console.WriteLine("End Parallel.");
        }

        public async Task<Country> ReadBahrainCountry()
        {
            string countryName = "Bahrain";
            var country = new Country();
            string filePath = $"D:\\MyWork\\Source_Control\\InMinutes\\Async_Parallel\\Jsons\\{countryName}.json";
            // The thread is now free! It's not sitting around waiting.
            Console.WriteLine($"{countryName} I'm free to update the UI or do other work...");
            string jsonContent = await File.ReadAllTextAsync(filePath);
            var countryData = JsonSerializer.Deserialize<Country>(jsonContent);
            if (countryData != null)
            { country = countryData; }
            return country;
        }
        public async Task<Country> ReadIraqCountry()
        {
            string countryName = "Iraq";
            var country = new Country();
            string filePath = $"D:\\MyWork\\Source_Control\\InMinutes\\Async_Parallel\\Jsons\\{countryName}.json";
            // The thread is now free! It's not sitting around waiting.
            Console.WriteLine($"{countryName} I'm free to update the UI or do other work...");
            string jsonContent = await File.ReadAllTextAsync(filePath);
            var countryData = JsonSerializer.Deserialize<Country>(jsonContent);
            if (countryData != null)
            { country = countryData; }

            return country;
        }

        /// <summary>
        /// No new threads were necessarily created here. 
        /// The operating system handles the network request, and .NET just waits for the signal to resume.
        /// </summary>
        /// <returns></returns>   
        public async Task<string[]> ReadCountriesAsync()
        {
            string filePath = $"D:\\MyWork\\Source_Control\\InMinutes\\Async_Parallel\\Jsons\\";
            string counry1 = "Bahrain";
            string filePath1 = $"{filePath}{counry1}.json";
            string counry2 = "Iraq";
            string filePath2 = $"{filePath}{counry2}.json";

            // Start the tasks (the "waiter" takes the orders)
            Task<string> task1 = File.ReadAllTextAsync(filePath1);
            Task<string> task2 = File.ReadAllTextAsync(filePath2);
            // The thread is now free! It's not sitting around waiting.
            Console.WriteLine("I'm free to update the UI or do other work...");

            // Now we "await" the results (the waiter checks if the food is ready)
            string[] results = await Task.WhenAll(task1, task2);

            return results;
        }


        ///// <summary>
        ///// This example simulates a heavy reading files (like reading large JSON files or processing large arrays).
        ///// This requires multiple threads because the CPU actually has to work.
        ///// Key Point: This uses the ThreadPool to spin up multiple workers.
        ///// If you have an 8-core CPU, .NET will try to use all of them to finish the math faster.
        ///// </summary>
        public void ReadDataInParallel()
        {
            string[] countries = { "Bahrain", "Iraq" };
            // Start timing
            Parallel.ForEach(countries, async country =>
            {
                string filePath = $"D:\\MyWork\\Source_Control\\InMinutes\\Async_Parallel\\Jsons\\{country}.json";
                string jsonContent = File.ReadAllTextAsync(filePath).Result;
                var countryData = JsonSerializer.Deserialize<Country>(jsonContent);
                Console.WriteLine($"{country}: {countryData?.Name_En}");
            });
        }
    }
}
