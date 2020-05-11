using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Threading.Tasks;


namespace ScriptDemo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Write some C#");
            var evaluate = true;

            while(evaluate)
            {
                var input = Console.ReadLine();

                if(input == "exit")
                {
                    evaluate = false;
                    break;
                }

                if(input == "clear")
                {
                    Console.Clear();
                    Console.WriteLine("Write some C#");
                    continue;
                }

                object result = await CSharpScript.EvaluateAsync(input);
                Console.WriteLine(result.ToString());
            }
        }
    }
}
