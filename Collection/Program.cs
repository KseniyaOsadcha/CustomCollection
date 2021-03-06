using System;
using System.Collections.Generic;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CustomDictionary<string, string> dict1 = new CustomDictionary<string, string>();

            dict1.Add("Spain", "Madrid");
            dict1.Add("Serbia", "Belgrade");
            dict1.Add("Slovakia", "Bratislava");
            dict1.Add("Finland", "Helsinki");
            dict1.Add("France", "Paris");
            dict1.Add("Georgia", "Tbilisi");
            dict1.Add("Greece", "Athens");

            Console.WriteLine("Values: ");
            foreach( string v in dict1.Values)
            {
                Console.WriteLine(v);

            }
            Console.WriteLine("Keys: ");
            foreach (string k in dict1.Keys)
            {
                Console.WriteLine(k);

            }
            Console.WriteLine("Count: ");
            Console.WriteLine(dict1.Count);

            dict1.Remove("Finland");
            Console.WriteLine("Values: ");
            foreach (string v in dict1.Values)
            {
                Console.WriteLine(v);

            }
            Console.WriteLine("Keys: ");
            foreach (string k in dict1.Keys)
            {
                Console.WriteLine(k);

            }
            Console.WriteLine("Count: ");
            Console.WriteLine(dict1.Count);

            Console.WriteLine("try to find Georgia: ");
            string value;
            dict1.TryGetValue("Georgia", out value);
            Console.WriteLine(value);

            Console.WriteLine("try to find smth: ");
            string value2;
            dict1.TryGetValue("smth", out value2);
            Console.WriteLine(value2);

            Console.WriteLine("is there Greece: ");
            Console.WriteLine(dict1.ContainsKey("Greece"));

            Console.WriteLine("get capital by key Spain: ");
            Console.WriteLine(dict1["Spain"]);

            Console.WriteLine("set capital by key Serbia: ");
            dict1["Serbia"] = "Belgrade2";
            Console.WriteLine(dict1["Serbia"]);

            Console.WriteLine("Clearing dict...");
            dict1.Clear();
            Console.WriteLine("Count: ");
            Console.WriteLine(dict1.Count);
        }
    }
}
