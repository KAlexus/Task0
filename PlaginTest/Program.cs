using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginLibrary;

namespace PlaginTest
{
    class Program
    {
        [Serializable]
        public class Test
        {
            public string Name { get; set; } = "NoName";
        }
        static void Main(string[] args)
        {
            bool exitFlag = true;

            while (exitFlag)
            {
                Menu();
                Console.Write("Select an action: ");
                string op = Console.ReadLine().Trim().ToLower();
                Console.WriteLine();

                switch (op)
                {
                    case "1":
                        Test1();
                        break;
                    case "2":
                        Test2();
                        break;
                    case "3":
                        Test3();
                        break;
                    case "e":
                        Console.WriteLine("EXIT!");
                        exitFlag = false;
                        break;
                    case "c":
                        Console.Clear();
                        Menu();
                        break;

                    default:
                        Console.WriteLine("Try Again.");
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("========== Simple Console Demo for PluginLibrary ==========");

            Console.WriteLine(" 1 - Test string;");
            Console.WriteLine(" 2 - Test numbers;");
            Console.WriteLine(" 3 - All test by Default;");

            Console.WriteLine(" E - Exit;");
            Console.WriteLine(" C - Clear screen.");
        }

        static void Test1()
        {
            Console.WriteLine("Enter string:");
            string value = Console.ReadLine();
            Console.WriteLine();
            Test1(value);
        }

        static void Test1(string value)
        {
            Plugin<string> pluginStr = new Plugin<string>();
            Console.WriteLine($"Current value: {value}\n");

            var clone = pluginStr.Clone(value);

            clone = pluginStr.ModifyToLower(value);
            Console.WriteLine($"ModifyToLower value: {clone}\n");

            clone = pluginStr.Absolute(value);
            Console.WriteLine($"Absolute value: {clone}\n");

            try
            {
                clone = pluginStr.ConvertToUtc(value).ToString();
            }
            catch (Exception)
            {
                
                Console.WriteLine("Cann't convert this string to DateTime");
            }
            
            Console.WriteLine($"ConvertToUtc value: {clone}\n");

            clone = pluginStr.MultiplyBy2(value);
            Console.WriteLine($"MultiplyBy2 value: {clone}\n");
        }
        static void Test2()
        {
            int value = 0;

            Console.WriteLine("Enter string:");
            string str = Console.ReadLine();
            Console.WriteLine();

            if (Int32.TryParse(str, out value))
                Test2(value);
            else
            {
                Console.WriteLine("Try again!");
            }
        }
        static void Test2(int value)
        {
            Plugin<int> pluginInt = new Plugin<int>();
            Console.WriteLine($"Current value: {value}\n");
            var clone = pluginInt.Clone(value);

            clone = pluginInt.ModifyToLower(value);
            Console.WriteLine($"ModifyToLower value: {clone}\n");
            
            clone = pluginInt.MultiplyBy2(value);
            Console.WriteLine($"MultiplyBy2 value: {clone}");

            Console.WriteLine($"ToWords value {value} :\n {pluginInt.ToWords(value)}");

            clone = pluginInt.Absolute(value);
            Console.WriteLine($"Absolute value: {clone}\n");

            Console.WriteLine($"Get sequence with length={clone}:");
            var sequence = pluginInt.Sequence(clone);
            pluginInt.PrintToConsole(sequence);
        }
        static void Test3()
        {
            Test1("Test for String");
            Console.WriteLine();
            Test1("2016/07/07");
            Console.WriteLine();
            Test2(-18);
            Console.WriteLine();
        }
    }
}
