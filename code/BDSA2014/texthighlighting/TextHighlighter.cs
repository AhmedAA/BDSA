using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BDSA13;

namespace texthighlighting
{
    /// <summary>
    /// Assignment 37 - Text highlighting.
    /// </summary>
    class TextHighlighter
    {
        static void Main(string[] args)
        {
            new TextHighlighter();
        }

        private readonly string[] _keywords = new[] { "exit", "help", "setfile", "show", "search" };
        private readonly Dictionary<string, string> _keywordDescriptions = new Dictionary<string, string>()
        {
            {"exit", "exit\tExit Text Highlighter. Sad to see you go!"},
            {"help", "help\tSee a list of all commands in Text Highlighter. Very helpful!"},
            {"setfile", "setfile [FILENAME]\tSet the file that you want to search through. A good place to start!"},
            {"show", "show\tShow the file as is, without searching in it. Pretty colours inbound!"},
            {"search", "search [SEARCHTERM]\tSearch through the set file for the given search term. Now the fun begins!"}
        };

        public TextHighlighter()
        {
            Console.WriteLine("Welcome to the Text Highlighter!");
            Console.WriteLine("Write help to see a list of commands.");
            Console.WriteLine();
            bool exit = false;
            string file = "testFile.txt";
            while (!exit)
            {
                // Read user input.
                string userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput == null) continue;
                // Split it into tokens to be able to check each token.
                string[] tokens = userInput.Split(' ');
                if (tokens.Length == 0) continue;
                if (!_keywords.Contains(tokens[0].ToLower()))
                {
                    WriteError("Command not found. Try typing \"help\"!");
                    
                }
                else
                {
                    if (tokens[0].ToLower().Equals("setfile"))
                    {
                        if (tokens.Length != 2)
                        {
                            // This keyword takes an argument, namely the file name.
                            // If it isn't there, print error and retry loop.
                            WriteError("No file name specified... Write: setfile [FILENAME]");
                            continue;
                        }
                        // Set the file, if the file given exists.
                        if (File.Exists(tokens[1]))
                        {
                            file = tokens[1];
                            WriteSuccess("File " + tokens[1] + " set!");
                        }
                        else
                        {
                            WriteError("File given doesn't exist...");
                        }
                    }
                    else if (tokens[0].ToLower().Equals("show"))
                    {
                        // Check if the user has set a file.
                        if (file == "")
                        {
                            // If file isn't set, print error message and retry the loop.
                            WriteError("No file set... Use the setfile command!");
                            continue;
                        }
                        // Highlighting the text can begin.
                        HightlightText(file, "");
                    }
                    else if (tokens[0].ToLower().Equals("search"))
                    {
                        // Check if the user has set a file.
                        if (file == "")
                        {
                            // If file isn't set, print error message and retry the loop.
                            WriteError("No file set... Use the setfile command!");
                            continue;
                        }
                        // Highlighting the text can begin.
                        HightlightText(file, tokens[1]);
                    }
                    else if (tokens[0].ToLower().Equals("help"))
                    {
                        foreach (string desc in _keywordDescriptions.Values)
                        {
                            Console.WriteLine(desc);
                        }
                        Console.WriteLine();
                    }
                    else if (tokens[0].ToLower().Equals("exit"))
                    {
                        // If user wants to exit, do exit!
                        Console.WriteLine("Exiting Text Highlight...");
                        Thread.Sleep(1000); // Just for fun :)
                        exit = true;
                    }
                }
            }
        }

        public void HightlightText(string inputFile, string searchTerm)
        {
            // Fetch the text from the input file.
            string input = TextFileReader.ReadFile(inputFile);
            string[] tokens = input.Split(' ');

            foreach (string token in tokens)
            {
                OrderedDictionary colouredTokens = new OrderedDictionary()
                {
                    {token, null}
                };

                FindUrls(ref colouredTokens);

                foreach (string colouredToken in colouredTokens.Keys)
                {
                    Console.ForegroundColor = (ConsoleColor)colouredTokens[colouredToken];
                    Console.Write(colouredToken);
                    Console.Write(" ");
                }
                
                // Write a space between each word.
                Console.Write(" ");
            }
        }

        private void FindUrls(ref OrderedDictionary tokens)
        {
            OrderedDictionary colouredTokens = new OrderedDictionary();
            Regex urlRegex = new Regex(@"(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$", RegexOptions.IgnoreCase);
            foreach (string token in tokens.Keys)
            {
                Match urlMatch = urlRegex.Match(token);
                if (urlMatch.Success)
                {
                    // If there are "normal" words before the url.
                    if (urlMatch.Index > 0)
                    {
                        colouredTokens[token.Substring(0, urlMatch.Index)] = ConsoleColor.White;
                    }
                    // Puts in the actual url.
                    colouredTokens.Add(urlMatch.Value, ConsoleColor.Blue);
                    // If there are "normal" words after the url.
                    if (urlMatch.Index + urlMatch.Length < token.Length)
                    {
                        colouredTokens[token.Substring(urlMatch.Index + urlMatch.Length)] = ConsoleColor.White;
                    }
                }
                else
                {
                    colouredTokens[token] = ConsoleColor.White;
                }
            }
            // Return the new dictionary by asigning it to the parameter given.
            tokens = colouredTokens;
        }

        private void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        private void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

    }
}
