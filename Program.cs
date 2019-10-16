using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;

namespace HttpConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var http = new HttpClient();
            //http.BaseAddress = new Uri("https://swapi.co");

            //http.GetAsync("https://swapi.co/api/people/");
            var jsonString = http.GetStringAsync("https://swapi.co/api/people/").Result;

            var jsonObject = JsonConvert.DeserializeObject<PeopleList>(jsonString);
            var people = jsonObject.People;

            Console.WriteLine(jsonString);

            var filteredPeople = people.Where(person => person.NumberOfVehicles > 0);

            foreach(var person in filteredPeople)
            {
                Console.WriteLine("Name: " + person.name);
                Console.WriteLine("Birth Year: " + person.birth_year);
                Console.WriteLine("Hair Color: " + person.HairColor);
                Console.WriteLine("Eye Color: " + person.eye_color);
                Console.WriteLine($"Gender: {person.gender}");
                //var mass2 = Convert.ToInt32(person.mass) + 10;
                Console.WriteLine($"Mass: {person.mass} \n");
                Console.WriteLine($"Mass: {person.mass + 10} \n");
                Console.WriteLine($"Number of Vehicles: {person.NumberOfVehicles}");
                //Console.WriteLine($"Mass2: {mass2} \n");
                foreach(var jsonUrl in person.vehiclesJson) 
                {
                    Console.WriteLine($"Vehicle: " + jsonUrl);
                    var result = http.GetStringAsync(jsonUrl).Result;
                    //var response = new HttpResponseMessage { };
                    var vehicle = JsonConvert.DeserializeObject<Vehicle>(result);
                    Console.WriteLine($"Model: {vehicle.model}");
                    Console.WriteLine($"Manufacturer: {vehicle.manufacturer}");
                    Console.WriteLine($"Name: {vehicle.name}");
                    Console.WriteLine($"Number of passengers: {vehicle.passengers}");
                }
                Console.WriteLine("");
            }
            var jsonStringResult = JsonConvert.SerializeObject(filteredPeople);
            Console.WriteLine("Returned JSON" + jsonStringResult);
            Console.ReadKey();
        }
    }
}
