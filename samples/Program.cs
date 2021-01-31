using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using HelpersToolbox.Extensions; 
// ReSharper disable ConditionIsAlwaysTrueOrFalse
#pragma warning disable 219

namespace HelpersToolbox.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("StringExtensions----");
            Console.WriteLine($"String is truncate if longer than 6 char > {"Lorem Ipsum is simply dummy text of the printing and".Truncate(10)}");
            Console.WriteLine($"EqualsWithIgnoreCase sample = SAMPLE > {"sample".EqualsWithIgnoreCase("SAMPLE")}");
            Console.WriteLine($"IsValidUrl (https://www.github.com) > {"https://www.github.com".IsValidUrl()}");
            var sampleJson = "{\"name\":\"turhany\"}";
            Console.WriteLine($"IsValidJson ({sampleJson}) > {sampleJson.IsValidJson()}");
            Console.WriteLine($"IsValidEmail (test@email.com) > {"test@email.com".IsValidEmail()}");

            Console.WriteLine();
            Console.WriteLine("EnumExtensions----");
            Console.WriteLine($"{nameof(Colors.Red)} enum description > {Colors.Red.GetDescription()}");

            List<string> cities = new List<string>{"İstanbul", "Ankara", "İzmir"};
            Console.WriteLine();
            Console.WriteLine("ListExtensions----");
            Console.WriteLine($"RemoveWere (Delete those starting with a) > {string.Join(',', cities.RemoveWhere(p => p.StartsWith("A")))}");
            var startsWithI = true;
            var filteredList = cities.WhereIf(p => p.StartsWith("İ"), startsWithI);
            Console.WriteLine($"WhereIf (add expression if condition is true) > {string.Join(',', filteredList)}");
            Console.WriteLine($"GetPage (pageNumber=1, pageSize=1) > {string.Join(',', cities.GetPage(1, 1))}");
            Console.WriteLine($"GetPage (pageNumber=1, pageSize=2) > {string.Join(',', cities.GetPage(1, 2))}");

            Console.WriteLine();
            Console.WriteLine("QueryableExtensions----");
            var startsWithIs = true;
            var filteredQueryableList = cities.AsQueryable().WhereIf(p => p.StartsWith("İs"), startsWithIs);
            Console.WriteLine($"WhereIf (add expression if condition is true) > {string.Join(',', filteredQueryableList)}");
            Console.WriteLine($"AddPaging (pageNumber=1, pageSize=1) > {string.Join(',', cities.AsQueryable().AddPaging(1,1))}");
            Console.WriteLine($"AddPaging (pageNumber=1, pageSize=2) > {string.Join(',', cities.AsQueryable().AddPaging(1,2))}");

            Console.WriteLine();
            Console.WriteLine("ObjectExtensions----");
            var person = new Person{Name = "Türhan"};
            Console.WriteLine($"GetPropertyValue (Name) > {person.GetPropertyValue<string>(nameof(Person.Name))}");
            person.SetPropertyValue(nameof(Person.Name), "Türhan Yıldırım");
            Console.WriteLine($"GetPropertyValue (Name) > {person.GetPropertyValue<string>(nameof(Person.Name))}");
            Console.WriteLine($"GetPropertyInfo (Name) > {person.GetPropertyInfo(nameof(Person.Name))}");
            Console.WriteLine($"HasProperty (Name) > {person.HasProperty(nameof(Person.Name))}");
            
            var clonedItem = ObjectExtensions.DeepClone<Person>(person);
            Console.WriteLine($"DeepClone (Name) > {clonedItem.Name}");

            Console.WriteLine();
            Console.WriteLine("ReflectionExtensions----");
            var info = Colors.Red.GetType().GetField(nameof(Colors.Red));
            Console.WriteLine($"GetAttribute (Description) > {info.GetAttribute<DescriptionAttribute>().Description}");
            Console.WriteLine($"HasAttribute (Description) > {info.HasAttribute<DescriptionAttribute>()}");

            cities = new List<string> { "İstanbul", "Ankara", "İzmir", "Adana", "Edirne" };
            var chunkedList = cities.Chunk(2);
            Console.WriteLine();
            Console.WriteLine("EnumerableExtensions----");
            Console.WriteLine($"Chunk/Batch (every batch/chunk has 2 element) > 5 item divided 2 item batch/chunk");
            var chunkIndex = 1;
            foreach (var chunk in chunkedList)
            {
                Console.WriteLine($"{chunkIndex}. chunk/batch > items -> {string.Join(',',chunk.ToList())}");
                chunkIndex++;
            }


            Console.ReadLine();
        }


        private enum Colors
        {
            [Description("Red color global description.")]
            Red = 0
        }

        private class Person
        { 
            public string Name { get; set; } 
        }
    }
}