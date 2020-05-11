using System;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Threading.Tasks;
using System.IO;
using Microsoft.CodeAnalysis.Scripting;

namespace ScriptDemo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var userScriptPath = Path.Combine(Environment.CurrentDirectory, "scriptInput.txt");
            var fileContents = File.ReadAllText(userScriptPath);

            Script script = CSharpScript.Create(fileContents, ScriptOptions.Default);
            var result = await script.RunAsync();
            
            Console.WriteLine($"Seconds in a week: {result.GetVariable("seconds").Value}");
        }

    }
}
