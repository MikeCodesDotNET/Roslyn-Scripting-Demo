﻿using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Threading.Tasks;
using System.Runtime;
using System.IO;

namespace ScriptDemo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            SetupProfiling();

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

                if(input == "clear" || string.IsNullOrEmpty(input))
                {
                    Console.Clear();
                    Console.WriteLine("Write some C#");
                    continue;
                }

                object result = await CSharpScript.EvaluateAsync(input);
                Console.WriteLine(result.ToString());
            }
        }


        static void SetupProfiling()
        {
            var profilesDir = Path.Combine(Environment.CurrentDirectory, "profiles");
            Directory.CreateDirectory(profilesDir);
            
            ProfileOptimization.SetProfileRoot(@profilesDir.ToString());
            ProfileOptimization.StartProfile("profile");
        }
    }
}
