// Intro to APIs Assignment 5
// Made using the https://official-joke-api.appspot.com/random_joke API

using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebAPIClient
{
    class Joke
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("setup")]
        public string Setup { get; set; }

        [JsonProperty("punchline")]
        public string Punchline { get; set; }
    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            while (true)
            {
                Console.WriteLine("Do you want to hear a joke? (y/n)");
                var answer = Console.ReadLine().ToLower();
                if (answer.Equals("y"))
                {
                    var result = await client.GetAsync("https://official-joke-api.appspot.com/random_joke");
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var joke = JsonConvert.DeserializeObject<Joke>(resultRead);

                    Console.WriteLine("\n---\n");
                    Console.WriteLine("Joke Type: " + joke.Type);
                    Console.WriteLine("Setup: " + joke.Setup);
                    Console.WriteLine("Punchline: " + joke.Punchline);
                    Console.WriteLine("\n---\n");
                }
                else if (answer.Equals("n"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter \"y\" or \"n\" as a response.");
                    continue;
                }
            }
        }
    }
}