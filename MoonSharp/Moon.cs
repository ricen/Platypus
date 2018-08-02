﻿using System;
using System.IO;

namespace MoonSharp {
    class Moon {
        private static bool errorEcountered = false;


        public static void Main(string[] args) {
            if(args.Length > 1) {
                Console.WriteLine("Usage: moonsharp [script]");
                return;
            }

            if(args.Length == 1) {
                RunScript(args[0]);
            }
            else {
                RunPrompt();
            }
        }

        public static void GenerateError(int line, string message) {
            ReportError(line, message);
            errorEcountered = true;
        }


        private static void RunPrompt() {
            while(true) {
                Console.Write("> ");
                Run(Console.ReadLine());
                errorEcountered = false;
            }
        }

        private static void RunScript(string scriptName) {
            string[] script;
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"{scriptName}");
            try {
                script = System.IO.File.ReadAllLines(path);
            }
            catch(System.IO.FileNotFoundException) {
                Console.WriteLine($"Error while opening script.");
                return;
            }

            Run(string.Join('\n', script));
            
            if(errorEcountered) {
                return;
            }
        }

        private static void Run(String source) {
            var lexer = new Lexer(source);
            var tokens = lexer.Tokenize();

            foreach(var token in tokens) {
                Console.WriteLine(token.ToString());
            }
        }

        private static void ReportError(int line, string message) {
            Console.WriteLine($"Error: line {line}, {message}");
        }
    }
}
