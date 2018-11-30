using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _08
{

    class Program
    {
        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }

        static void Main(string[] args)
        {
            //part 1 
            var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt", Encoding.ASCII).ToList();

            string all = String.Join(String.Empty, lines);

            var unescaped = lines.Select(x => Regex.Unescape(x.Substring(1, x.Length - 2))).ToList();

            string unescapedAll = String.Join(String.Empty, unescaped);

            Console.WriteLine(all.Length - unescapedAll.Length);

            Console.ReadKey();

            //part2
            var doubleEscapedCount = 0;

            foreach(var line in lines)
            {
                doubleEscapedCount += ToLiteral(line).Length;
            }

            Console.WriteLine(doubleEscapedCount - all.Length);

            Console.ReadKey();
        }
    }
}