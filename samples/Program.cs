﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using HelpersToolbox.Extensions;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
#pragma warning disable 219

namespace HelpersToolbox.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("StringExtensions----");
            Console.WriteLine($"String is truncate if longer than 6 char > {"Lorem Ipsum is simply dummy text of the printing and".Truncate(10)}");
            Console.WriteLine($"EqualsWithIgnoreCase sample = SAMPLE > {"sample".EqualsWithIgnoreCase("SAMPLE")}");
            Console.WriteLine($"IsValidUrl (https://www.github.com) > {"https://www.github.com".IsValidUrl()}");
            var sampleJson = "{\"name\":\"turhany\"}";
            Console.WriteLine($"IsValidJson ({sampleJson}) > {sampleJson.IsValidJson()}");
            Console.WriteLine($"IsValidEmail (test@email.com) > {"test@email.com".IsValidEmail()}");
            Console.WriteLine($"ComputeHashSha(Key: test) (turhany) > {"turhany".ComputeHashSha("test")}");
            Console.WriteLine($"SanitizeHtml(<img src='src' onerror=alert(document.cookie)>deneme) > {"<img src='src' onerror=alert(document.cookie)>deneme".SanitizeHtml()}");
            Console.WriteLine($"Slugify (Türhan Yıldırım) > {"Türhan Yıldırım".Slugify()}");
            Console.WriteLine($"FromJson ({sampleJson}) > Person.Name = {sampleJson.FromJson<Person>().Name}");
            Console.WriteLine($"HashPassword (turhany) > {"turhany".HashPassword()}");
            Console.WriteLine($"VerifyPassword (turhany) > {"turhany".VerifyPassword("turhany".HashPassword())}");
            var sampleFilePath = Path.Combine(Environment.CurrentDirectory, "logo.png");
            Console.WriteLine($"GetFileEncodingByFilePath ({sampleFilePath}) > {sampleFilePath.GetFileEncodingByFilePath()}");
            var sampleZipFileWithPassPath = Path.Combine(Environment.CurrentDirectory, "withpass.zip");
            var sampleZipFileWithoutPassPath = Path.Combine(Environment.CurrentDirectory, "withoutpass.zip");
            Console.WriteLine($"IsPasswordProtectedZipFile ({sampleZipFileWithPassPath}) > {sampleZipFileWithPassPath.IsPasswordProtectedZipFile()}");
            Console.WriteLine($"IsPasswordProtectedZipFile ({sampleZipFileWithoutPassPath}) > {sampleZipFileWithoutPassPath.IsPasswordProtectedZipFile()}");
            var minifyHtmlResult = "<img src='src' onerror=alert(document.cookie)>deneme".MinifyHtml(true);
            Console.WriteLine($"MinifyHtml(<img src='src' onerror=alert(document.cookie)>deneme) > SavedInPercent: {minifyHtmlResult.Statistics.SavedInPercent}");
            Console.WriteLine($"MinifyHtml(<img src='src' onerror=alert(document.cookie)>deneme) > MinifiedContent: {minifyHtmlResult.MinifiedContent}");
            Console.WriteLine($"IsValidIp (192.168.1.1) > {"192.168.1.1".IsValidIp()}");
            Console.WriteLine($"IsValidIp (192.168.1.a) > {"192.168.1.a".IsValidIp()}");
            Console.WriteLine($"IsValidIpRange (192.168.1.2/20) > {"192.168.1.2/20".IsValidIpRange()}");
            Console.WriteLine($"IsValidIpRange (192.168.1.2-20) > {"192.168.1.2-20".IsValidIpRange()}");
            Console.WriteLine($"IsValidIpRange (192.168.1.2-192.168.1.20) > {"192.168.1.2-192.168.1.20".IsValidIpRange()}");
            Console.WriteLine($"IsInIpRange (192.168.1.2-6 is in 192.168.1.2/20) > {"192.168.1.6".IsInIpRange("192.168.1.2/20")}");

            
            Console.WriteLine();
            Console.WriteLine("EnumExtensions----");
            Console.WriteLine($"{nameof(Colors.Red)} enum description > {Colors.Red.GetDescription()}");
            Console.WriteLine($"{nameof(Colors)} get all enum list - EnumToList >  Keys  = {string.Join(";",EnumExtensions.EnumToList<Colors>().Select(p => p.Key))}");
            Console.WriteLine($"{nameof(Colors)} get all enum list - EnumToList >  Values  = {string.Join(";",EnumExtensions.EnumToList<Colors>().Select(p => p.Value))}");

            List<string> cities = new List<string> {"İstanbul", "Ankara", "İzmir"};
            Console.WriteLine();
            Console.WriteLine("ListExtensions----");
            Console.WriteLine($"RemoveWere (Delete those starting with a) > {string.Join(',', cities.RemoveWhere(p => p.StartsWith("A")))}");
            var startsWithI = true;
            var filteredList = cities.WhereIf(p => p.StartsWith("İ"), startsWithI);
            Console.WriteLine($"WhereIf (add expression if condition is true) > {string.Join(',', filteredList)}");
            Console.WriteLine($"GetPage (pageNumber=1, pageSize=1) > {string.Join(',', cities.GetPage(1, 1))}");
            Console.WriteLine($"GetPage (pageNumber=1, pageSize=2) > {string.Join(',', cities.GetPage(1, 2))}");
            Console.WriteLine($"SelectRandomFromList > {string.Join(',', cities.SelectRandomFromList(1))}");
            Console.WriteLine($"SelectRandomFromList > {string.Join(',', cities.SelectRandomFromList(1))}");
            Console.WriteLine($"Shuffle > {string.Join(',', cities.Shuffle())}");
            Console.WriteLine($"Shuffle > {string.Join(',', cities.Shuffle())}");

            Console.WriteLine();
            Console.WriteLine("QueryableExtensions----");
            var startsWithIs = true;
            var filteredQueryableList = cities.AsQueryable().WhereIf(p => p.StartsWith("İs"), startsWithIs);
            Console.WriteLine($"WhereIf (add expression if condition is true) > {string.Join(',', filteredQueryableList)}");
            Console.WriteLine($"AddPaging (pageNumber=1, pageSize=1) > {string.Join(',', cities.AsQueryable().AddPaging(1, 1))}");
            Console.WriteLine($"AddPaging (pageNumber=1, pageSize=2) > {string.Join(',', cities.AsQueryable().AddPaging(1, 2))}");

            Console.WriteLine();
            Console.WriteLine("ObjectExtensions----");
            var person = new Person {Name = "Türhan"};
            Console.WriteLine($"GetPropertyValue (Name) > {person.GetPropertyValue<string>(nameof(Person.Name))}");
            person.SetPropertyValue(nameof(Person.Name), "Türhan Yıldırım");
            Console.WriteLine($"GetPropertyValue (Name) > {person.GetPropertyValue<string>(nameof(Person.Name))}");
            Console.WriteLine($"GetPropertyInfo (Name) > {person.GetPropertyInfo(nameof(Person.Name))}");
            Console.WriteLine($"HasProperty (Name) > {person.HasProperty(nameof(Person.Name))}");
            Console.WriteLine($"GetFieldValue (TestField) > {person.GetFieldValue<string>(nameof(Person.TestField))}");
            Console.WriteLine($"GetFieldInfo (TestField) > {person.GetFieldInfo(nameof(Person.TestField))}");
            Console.WriteLine($"HasField (TestField) > {person.HasField(nameof(Person.TestField))}");
            Console.WriteLine($"ToJson > {person.ToJson()}");
            Console.WriteLine($"{nameof(Colors.Blue)} enum display name > {Colors.Blue.GetDisplayName()}");

            var clonedItem = person.DeepClone();
            Console.WriteLine($"DeepClone - Original Object hashCode > {person.GetHashCode()}");
            Console.WriteLine($"DeepClone - Original Object hashCode > {clonedItem.GetHashCode()}");
            Console.WriteLine($"DeepClone (Name) > {clonedItem.Name}");

            Console.WriteLine();
            Console.WriteLine("ReflectionExtensions----");
            var info = Colors.Red.GetType().GetField(nameof(Colors.Red));
            Console.WriteLine($"GetAttribute (Description) > {info.GetAttribute<DescriptionAttribute>().Description}");
            Console.WriteLine($"HasAttribute (Description) > {info.HasAttribute<DescriptionAttribute>()}");

            cities = new List<string> {"İstanbul", "Ankara", "İzmir", "Adana", "Edirne"};
            var batchedList = cities.Batch(2);
            Console.WriteLine();
            Console.WriteLine("EnumerableExtensions----");
            Console.WriteLine($"Batch (every batch has 2 element) > 5 item divided 2 item batch");
            var batchIndex = 1;
            foreach (var batch in batchedList)
            {
                Console.WriteLine($"{batchIndex}. batch > items -> {string.Join(',', batch.ToList())}");
                batchIndex++;
            }

            var citiesDictionary1 = new Dictionary<string, string> {{"istanbul", "istanbul"}};
            var citiesDictionary2 = new Dictionary<string, string> {{"izmir", "izmir"}};
            Console.WriteLine();
            Console.WriteLine("DictionaryExtensionMethods----");
            citiesDictionary1.Merge(citiesDictionary2); 
            Console.WriteLine($"Merge (Dict1 = istanbul, Dict2 = izmir ) > {string.Join(',',citiesDictionary1.Select(p => p.Key).ToList())}");

            Console.WriteLine();
            Console.WriteLine("ByteExtensions----");
            byte byteEnum = 1;
            Console.WriteLine($"Byte: {byteEnum} ToEnum cast (Color.Blue = 1) > {byteEnum.ToEnum<Colors>()}");
            Console.WriteLine($"Byte: {byteEnum} IsEnumValueValid cast (Color.Blue = 1) > {byteEnum.IsEnumValueValid<Colors>()}");
            
            Console.WriteLine();
            Console.WriteLine("IntExtensions----");
            int intEnum = 1;
            Console.WriteLine($"int: {intEnum} ToEnum cast (Color.Blue = 1) > {intEnum.ToEnum<Colors>()}");
            Console.WriteLine($"Byte: {intEnum} IsEnumValueValid cast (Color.Blue = 1) > {intEnum.IsEnumValueValid<Colors>()}");
            Int64 int64Enum = 1;
            Console.WriteLine($"int64: {int64Enum} ToEnum cast (Color.Blue = 1) > {int64Enum.ToEnum<Colors>()}");
            Console.WriteLine($"Byte: {int64Enum} IsEnumValueValid cast (Color.Blue = 1) > {int64Enum.IsEnumValueValid<Colors>()}");
            
            Console.WriteLine();
            Console.WriteLine("BoolExtensions----");
            Console.WriteLine($"True bool to  AsYesNo > {true.AsYesNo()}");
            Console.WriteLine($"False bool to  AsYesNo > {false.AsYesNo()}");
            bool? testBool = null;
            Console.WriteLine($"Null (nullable)bool to  AsYesNo > {testBool.AsYesNo()}");
            testBool = true;
            Console.WriteLine($"True (nullable)bool to  AsYesNo > {testBool.AsYesNo()}");
            testBool = false;
            Console.WriteLine($"False (nullable)bool to  AsYesNo > {testBool.AsYesNo()}");
            
            Console.WriteLine();
            Console.WriteLine("MessagePackExtensions----");
            var serializedPerson = MessagePackExtensions.Serialize(person);
            var deserializedPerson = MessagePackExtensions.Deserialize<Person>(serializedPerson);
            Console.WriteLine($"Serialize Person as byte array> {Encoding.UTF8.GetString(serializedPerson, 0, serializedPerson.Length)}");
            Console.WriteLine($"Deserialize Person.Name> {deserializedPerson.Name}");

            Console.WriteLine();
            Console.WriteLine("MachineExtensions----");
            Console.WriteLine($"GetIPV4Addresses > {string.Join("," ,MachineExtensions.GetIPV4Addresses().Select(p => p.ToString()).ToList())}");
            Console.WriteLine($"GetIPV6Addresses > {string.Join(",", MachineExtensions.GetIPV6Addresses().Select(p => p.ToString()).ToList())}");

            Console.ReadLine();
        }


        private enum Colors
        {
            [Description("Red color global description.")]
            Red = 0,
            [Display(Name = "Blue Display Name")]
            [Description("Blue color global description.")]
            Blue = 1
        }

        public class Person
        {
            public string TestField = "TestFieldValue";
            public string Name { get; set; }
        }
    }
}