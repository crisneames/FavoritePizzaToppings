//Turn json into C# objects

//// read file into a string and deserialize JSON to a type
//Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"c:\movie.json"));

//// deserialize JSON directly from a file
//using (StreamReader file = File.OpenText(@"c:\movie.json"))
//{
//    JsonSerializer serializer = new JsonSerializer();
//    Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
//}

using FavoritePizzaToppings;
using Newtonsoft.Json;

var allPizzas = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText("C:\\Users\\crisn\\source\\repos\\FavoritePizzaToppings\\Assets\\pizzas.json"));

//var distinctTopings = pizza.Select(x => x.Toppings).Distinct(); => doesn't work in this case

Dictionary<string, int> pizzaCounter = new Dictionary<string, int>();

foreach (Pizza pizza in allPizzas)
{
    var toppingsAsString = String.Join("," ,pizza.Toppings);
    if (pizzaCounter.ContainsKey(toppingsAsString))
    {
        pizzaCounter[toppingsAsString] += 1;
    }
    else
    {
        pizzaCounter[toppingsAsString] = 1;
    }
 
}

var mostCommonPizzas = pizzaCounter.OrderByDescending(p => p.Value).Take(20);
foreach (var item in mostCommonPizzas)
{
    Console.WriteLine($"{item.Key} {item.Value}");
}


//Console.WriteLine(allPizzas.Count);




