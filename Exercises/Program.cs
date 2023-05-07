using System;
using System.Linq;
using System.Linq.Expressions;

namespace Exercises
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("List of numbers greater than 30 and less than 100:");
            Greatthan30AndLess100();

            Console.WriteLine("Uppercase words at least 5 characters long:");
            CharacterLength();

            Console.WriteLine("Words starting with letter 'a' and ending with letter 'm' in list:");
            StartaEndm();

            Console.WriteLine("Top 5 numbers in descending order:");
            DescendingOrder();

            Console.WriteLine("Square numbers are greater than 20 in list:");
            SquareGreaterThan20();

            Console.WriteLine("Replaces 'ea'with an '*' in list: ");
            ReplaceLetters();

            Console.WriteLine("The first word contains 'e' in list:");
            Contains();

            Console.WriteLine("Digit corresponds to a given special char on the keyboard:");
            Console.WriteLine(ReplaceSpecialChar("*$(#&"));

            Console.WriteLine("The most frequent character in string");
            FrequentChar("n093nfv034nie9");

            Console.WriteLine("Unique strings:");
            OnlyUniqueStrings();

            Console.WriteLine("Uppercase words in string:");
            UppercaseWords("DDD example CQRS Event Sourcing");

            Console.WriteLine("The dot product of two arrays:");
            DotProduct();

            Console.WriteLine("Number of letters in string:");
            CountLetters("gamma");
        }

        public static List<int> Greatthan30AndLess100()
        {
            List<int> list = new List<int>() { 67, 92, 153, 15 };

            list = list.Where(i => i > 30 && i < 100).ToList();

            Console.WriteLine(string.Join(", ", list));

            return list;
        }

        public static List<string> CharacterLength()
        {
            List<string> list = new List<string>() { "computer", "usb", "keyboard", "mouse" };

            list = list.Where(s => s.Length >= 5).Select(s => s.ToUpper()).ToList();

            Console.WriteLine(string.Join(", ", list));

            return list;
        }

        public static List<string> StartaEndm()
        {
            List<string> list = new List<string>() { "mum", "amsterdam", "bloom" };

            list = list.Where(s => s.StartsWith("a") && s.EndsWith("m")).ToList();

            Console.WriteLine(string.Join(", ", list));

            return list;
        }

        public static List<int> DescendingOrder()
        {
            List<int> list = new List<int>() { 78, -9, 0, 23, 54, 21, 7, 86 };

            list = list.OrderByDescending(i => i).Take(5).ToList();

            Console.WriteLine(string.Join(", ", list));

            return list;
        }

        public static List<string> SquareGreaterThan20()
        {
            List<int> List = new List<int>() { 7, 2, 30 };

            List<string> result = List.Where(i => i * i > 20).Select(i => $"{i} - {i * i}").ToList();

            Console.WriteLine(string.Join(", ", result));

            return result;

        }

        public static List<string> ReplaceLetters()
        {
            List<string> list = new List<string>() { "learn", "current", "deal" };

            list = list.Select(s => s.Replace("ea", "*")).ToList();

            Console.WriteLine(string.Join(", ", list));

            return list;
        }

        public static List<string> Contains()
        {
            List<string> list = new List<string>() { "plane", "ferry", "car", "bike" };

            var first = list.OrderBy(s => s).FirstOrDefault(s => s.Contains("e"));

            Console.WriteLine(first);

            return list;
        }

        public static string ReplaceSpecialChar(string input)
        {
            var numberByCharacters = new Dictionary<char, byte>{
                { '!', 1 },
                { '@', 2 },
                { '#', 3 },
                { '$', 4 },
                { '%', 5 },
                { '^', 6 },
                { '&', 7},
                { '*', 8},
                { '(', 9},
                { ')', 0}
            };

            return input.Aggregate("", (accumulator, current) => $"{accumulator}{numberByCharacters.GetValueOrDefault(current)}");
            //var map = new[] { new { character = '!', number = 1 }, };
            //var toNumbers = "())(".Select(c => map.Single(e => e.character == c).number);
        }
        public static string FrequentChar(string s)
        {

            var S = s.GroupBy(s => s).OrderByDescending(s => s.Count()).First().Key;

            Console.WriteLine(S);

            return s;
        }
        //No
        public static List<string> OnlyUniqueStrings()
        {
            List<string> list = new List<string>() { "abc", "xyz", "klm", "xyz", "abc", "abc", "rst" };

            list = list.GroupBy(s => s).Where(s => s.Count() == 1).Select(s => s.Key).ToList();

            Console.WriteLine(string.Join(", ", list));

            return list;
        }
        public static string UppercaseWords(string String)
        {

            var uppercaseWords = String.Split(' ').Where(s => s.All(c => char.IsUpper(c))).ToList();

            Console.WriteLine(string.Join(", ", uppercaseWords));

            return String;

        }

        public static int DotProduct()
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };

            int dotProduct = array1.Zip(array2, (a, b) => a * b).Sum();

            Console.WriteLine(dotProduct);

            return dotProduct;
        }

        public static string CountLetters(string Word)
        {
            var letterFrequencies = Word.GroupBy(s => s).ToDictionary(x => x.Key, x => x.Count());

            foreach (var g in letterFrequencies)
            {
                Console.WriteLine("Letter {0} occurs {1} times", g.Key, g.Value);
            }

            return Word;
        }
    }
}
